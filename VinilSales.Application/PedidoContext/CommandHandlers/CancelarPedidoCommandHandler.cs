using MediatR;
using System.Threading;
using System.Threading.Tasks;
using VinilSales.Application.CoreContext.Interfaces;
using VinilSales.Application.PedidoContext.Command;
using VinilSales.Application.PedidoContext.Notification;
using VinilSales.Domain.PedidoContext.Enum;
using VinilSales.Repository.Domain.PedidoContext.Interfaces;

namespace VinilSales.Application.PedidoContext.CommandHandlers
{
    public class CancelarPedidoCommandHandler : IRequestHandler<CancelarPedidoCommand, bool>
    {
        private readonly IMediator _mediator;
        private readonly IPedidoRepository _repository;
        private readonly IValidationHandler _validation;

        public CancelarPedidoCommandHandler(IValidationHandler validation, IMediator mediator, IPedidoRepository repository)
        {
            _validation = validation;
            _mediator = mediator;
            _repository = repository;
        }

        public async Task<bool> Handle(CancelarPedidoCommand request, CancellationToken cancellationToken)
        {
            var pedido = await _repository.ObterPorId(request.IdPedido);
            if (pedido.StatusEnum == PedidoStatusEnum.Cancelado)
            {
                _validation.Add("O pedido já está cancelado.");
                return false;
            }

            var result = await _repository.CancelarPedido(request.IdPedido);
            if (result)
            {
                await _mediator.Publish(new PedidoCanceladoNotification(request.IdPedido));
            }

            return result;
        }
    }
}
