using MediatR;
using System.Threading;
using System.Threading.Tasks;
using VinilSales.Application.PedidoContext.Command;
using VinilSales.Application.PedidoContext.Notification;
using VinilSales.Repository.Domain.PedidoContext.Interfaces;

namespace VinilSales.Application.PedidoContext.CommandHandlers
{
    public class CancelarPedidoCommandHandler : IRequestHandler<CancelarPedidoCommand, bool>
    {
        private readonly IMediator _mediator;
        private readonly IPedidoRepository _repository;

        public CancelarPedidoCommandHandler(IMediator mediator, IPedidoRepository repository)
        {
            _mediator = mediator;
            _repository = repository;
        }

        public async Task<bool> Handle(CancelarPedidoCommand request, CancellationToken cancellationToken)
        {
            var result = await _repository.CancelarPedido(request.IdPedido);
            if (result)
            {
                await _mediator.Publish(new PedidoCanceladoNotification(request.IdPedido));
            }
            return result;
        }
    }
}
