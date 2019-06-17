using System.Linq;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using VinilSales.Application.PedidoContext.Command;
using VinilSales.Application.PedidoContext.Notification;
using VinilSales.Repository.Domain.PedidoContext.Interfaces;
using VinilSales.Application.CoreContext.Interfaces;
using VinilSales.Domain.PedidoContext.Enum;

namespace VinilSales.Application.PedidoContext.CommandHandlers
{
    public class FinalizarPedidoCommandHandler : IRequestHandler<FinalizarPedidoCommand, bool>
    {
        private readonly IMediator _mediator;
        private readonly IPedidoRepository _repository;
        private readonly IValidationHandler _validation;

        public FinalizarPedidoCommandHandler(IValidationHandler validation, IMediator mediator, IPedidoRepository repository)
        {
            _validation = validation;
            _mediator = mediator;
            _repository = repository;
        }

        public async Task<bool> Handle(FinalizarPedidoCommand request, CancellationToken cancellationToken)
        {
            var pedido = await _repository.ObterPorId(request.IdPedido);
            if (pedido.StatusEnum == PedidoStatusEnum.Finalizado)
            {
                _validation.Add("O pedido já está finalizado.");
                return false;
            }

            var result = await _repository.FinalizarPedido(request.IdPedido);
            if (result)
            {
                var valorTransacao = pedido.Itens.Sum(a => a.ValorCashback);
                await _mediator.Publish(new PedidoFinalizadoNotification(pedido.IdCliente, pedido.IdPedido, pedido.ValorPedido, valorTransacao));
            }
            return result;
        }
    }
}
