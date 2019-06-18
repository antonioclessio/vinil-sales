using System.Linq;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using VinilSales.Application.CoreContext.CommandHandlers;
using VinilSales.Application.PedidoContext.Command;
using VinilSales.Application.ProdutoContext.Queries;
using VinilSales.Application.TabelaCashbackContext.Queries;
using VinilSales.Repository.Domain.PedidoContext.Entities;
using VinilSales.Repository.Domain.PedidoContext.Interfaces;
using System;
using VinilSales.Application.PedidoContext.Notification;
using VinilSales.Application.TabelaCashbackContext.Result;
using VinilSales.Domain.CoreContext.Interfaces;

namespace VinilSales.Application.PedidoContext.CommandHandlers
{
    public class CriarPedidoCommandHandler : BaseHandler<IPedidoRepository>, IRequestHandler<CriarPedidoCommand, bool>
    {
        public CriarPedidoCommandHandler(IValidationMessage validation, IMediator mediator, IPedidoRepository repository)
            : base(validation, mediator, repository)
        {
        }

        public override void ConfigureMapper()
        {
            _mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CriarPedidoCommand, PedidoEntity>();
                cfg.CreateMap<CriarPedido_ItemCommand, Pedido_ItemEntity>();
            }).CreateMapper();
        }

        public async Task<bool> Handle(CriarPedidoCommand request, CancellationToken cancellationToken)
        {
            var tabelaCashbackVigente = await _mediator.Send(new ObterVigenteQuery());

            var novoPedido = _mapper.Map<PedidoEntity>(request);
            novoPedido.IdTabelaCashback = tabelaCashbackVigente.IdTabelaCashback;
            
            request.Itens.ForEach(item =>
            {
                var valoresProduto = calcularValoresProduto(tabelaCashbackVigente, item.IdProduto);
                var novoItem = _mapper.Map<Pedido_ItemEntity>(item);
                novoItem.ValorUnitario = valoresProduto.ValorUnitario;
                novoItem.PercentualCashback = valoresProduto.PercentualCashback;
                novoPedido.Itens.Add(novoItem);
            });

            novoPedido.ValorPedido = novoPedido.Itens.Sum(a => a.ValorUnitario * a.Quantidade);

            if (novoPedido.Invalido)
            {
                _validation.AddRange(novoPedido.Mensagens);
                return false;
            }

            var result = await _repository.CriarPedido(novoPedido);
            if (result > 0)
            {
                await _mediator.Publish(new PedidoCriadoNotification(result));
            }

            return true;
        }

        private ValoresProduto calcularValoresProduto(ObterVigenteResult tabelaCashbackVigente, int idProduto)
        {
            var produtoEntity = _mediator.Send(new ObterProdutoQuery(idProduto)).Result;
            var tabelaCashbackItens = tabelaCashbackVigente.Itens.Find(a => a.Genero == (byte)produtoEntity.GeneroEnum);

            decimal valorCashback = 0;

            switch (DateTime.Now.DayOfWeek)
            {
                case DayOfWeek.Sunday: valorCashback = tabelaCashbackItens.Domingo; break;
                case DayOfWeek.Monday: valorCashback = tabelaCashbackItens.Segunda; break;
                case DayOfWeek.Tuesday: valorCashback = tabelaCashbackItens.Terca; break;
                case DayOfWeek.Wednesday: valorCashback = tabelaCashbackItens.Quarta; break;
                case DayOfWeek.Thursday: valorCashback = tabelaCashbackItens.Quinta; break;
                case DayOfWeek.Friday: valorCashback = tabelaCashbackItens.Sexta; break;
                case DayOfWeek.Saturday: valorCashback = tabelaCashbackItens.Sabado; break;
            }

            return new ValoresProduto
            {
                ValorUnitario = produtoEntity.Preco,
                PercentualCashback = valorCashback
            };
        }

        private class ValoresProduto
        {
            public decimal ValorUnitario { get; set; }
            public decimal PercentualCashback { get; set; }
        }
    }
}
