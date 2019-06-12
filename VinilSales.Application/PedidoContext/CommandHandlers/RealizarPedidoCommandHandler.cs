using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using VinilSales.Application.CoreContext.Base;
using VinilSales.Application.PedidoContext.Command;
using VinilSales.Application.ProdutoContext.Queries;
using VinilSales.Application.TabelaCashbackContext.Queries;
using VinilSales.Repository.Domain.PedidoContext.Interfaces;

namespace VinilSales.Application.PedidoContext.CommandHandlers
{
    public class RealizarPedidoCommandHandler : IRequestHandler<RealizarPedidoCommand, bool>
    {
        private readonly IMediator _mediator;
        private readonly IPedidoRepository _repository;

        public RealizarPedidoCommandHandler(IMediator mediator, IPedidoRepository repository)
        {
            _mediator = mediator;
            _repository = repository;
        }

        public async Task<bool> Handle(RealizarPedidoCommand request, CancellationToken cancellationToken)
        {
            var produtoEntity = await _mediator.Send(new ObterProdutoQuery(request.IdProduto));
            var percentualCashback = await _mediator.Send(new ObterPercentualCashbackDiaQuery(produtoEntity.GeneroEnum));

            

            return false;
        }
    }
}
