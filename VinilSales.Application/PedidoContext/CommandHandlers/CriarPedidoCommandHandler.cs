using System.Linq;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using VinilSales.Application.CoreContext.Base;
using VinilSales.Application.PedidoContext.Command;
using VinilSales.Application.ProdutoContext.Queries;
using VinilSales.Application.TabelaCashbackContext.Queries;
using VinilSales.Repository.Domain.PedidoContext.Entities;
using VinilSales.Repository.Domain.PedidoContext.Interfaces;
using System;

namespace VinilSales.Application.PedidoContext.CommandHandlers
{
    public class CriarPedidoCommandHandler : BaseHandler<IPedidoRepository>, IRequestHandler<CriarPedidoCommand, bool>
    {
        public CriarPedidoCommandHandler(IMediator mediator, IPedidoRepository repository)
            : base(mediator, repository)
        {
            _mediator = mediator;
            _repository = repository;
        }

        public override void ConfigureMapper()
        {
            _mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CriarPedidoCommand, PedidoEntity>();
            }).CreateMapper();
        }

        public async Task<bool> Handle(CriarPedidoCommand request, CancellationToken cancellationToken)
        {
            var novoPedido = _mapper.Map<PedidoEntity>(request);
            var dadosCashback = await obterValorCashback(request.IdProduto);

            novoPedido.IdTabelaCashback = dadosCashback.Item1;
            novoPedido.ValorCashback = dadosCashback.Item2;

            await _repository.CriarPedido(novoPedido);

            return true;
        }

        private async Task<Tuple<int, decimal>> obterValorCashback(int idProduto)
        {
            var produtoEntity = await _mediator.Send(new ObterProdutoQuery(idProduto));
            var tabelaCashbackVigente = await _mediator.Send(new ObterVigenteQuery());
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

            return new Tuple<int, decimal>(tabelaCashbackVigente.IdTabelaCashback, valorCashback);
        }
    }
}
