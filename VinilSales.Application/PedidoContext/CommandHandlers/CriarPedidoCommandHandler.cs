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

            var produtoEntity = await _mediator.Send(new ObterProdutoQuery(request.IdProduto));
            var tabelaCashbackVigente = await _mediator.Send(new ObterVigenteQuery());

            novoPedido.IdTabelaCashback = tabelaCashbackVigente.IdTabelaCashback;

            return true;
        }


    }
}
