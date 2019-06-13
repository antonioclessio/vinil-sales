using System.Linq;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using VinilSales.Application.PedidoContext.Command;
using VinilSales.Application.PedidoContext.Notification;
using VinilSales.Repository.Domain.PedidoContext.Interfaces;

namespace VinilSales.Application.PedidoContext.CommandHandlers
{
    public class FinalizarPedidoCommandHandler : IRequestHandler<FinalizarPedidoCommand, bool>
    {
        private readonly IMediator _mediator;
        private readonly IPedidoRepository _repository;

        public FinalizarPedidoCommandHandler(IMediator mediator, IPedidoRepository repository)
        {
            _mediator = mediator;
            _repository = repository;
        }

        public async Task<bool> Handle(FinalizarPedidoCommand request, CancellationToken cancellationToken)
        {
            var result = await _repository.FinalizarPedido(request.IdPedido);
            if (result)
            {
                var pedido = await _repository.ObterPorId(request.IdPedido);
                var valorTransacao = pedido.Itens.Sum(a => a.ValorCashback);
                await _mediator.Publish(new PedidoFinalizadoNotification(pedido.IdCliente, pedido.IdPedido, pedido.ValorPedido, valorTransacao));
            }
            return result;
        }
    }
}
