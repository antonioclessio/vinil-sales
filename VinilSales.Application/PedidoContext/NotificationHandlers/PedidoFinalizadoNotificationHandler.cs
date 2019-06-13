using System.Threading;
using System.Threading.Tasks;
using MediatR;
using VinilSales.Application.ClienteContext.Commands;
using VinilSales.Application.PedidoContext.Notification;

namespace VinilSales.Application.PedidoContext.NotificationHandlers
{
    public class PedidoFinalizadoNotificationHandler : INotificationHandler<PedidoFinalizadoNotification>
    {
        private readonly IMediator _meditor;
        public PedidoFinalizadoNotificationHandler(IMediator mediator)
        {
            this._meditor = mediator;
        }

        public async Task Handle(PedidoFinalizadoNotification notification, CancellationToken cancellationToken)
        {
            await _meditor.Send(new RegistrarTransacaoCreditoCashbackCommand(
                notification.IdCliente, 
                notification.IdPedido, 
                notification.ValorPedido, 
                notification.PercentualCashback, 
                notification.ValorTransacao));
        }
    }
}
