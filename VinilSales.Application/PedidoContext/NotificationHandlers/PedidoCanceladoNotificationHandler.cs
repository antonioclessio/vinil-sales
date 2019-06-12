﻿using System.Threading;
using System.Threading.Tasks;
using MediatR;
using VinilSales.Application.PedidoContext.Notification;

namespace VinilSales.Application.PedidoContext.NotificationHandlers
{
    public class PedidoCanceladoNotificationHandler : INotificationHandler<PedidoCanceladoNotification>
    {
        public Task Handle(PedidoCanceladoNotification notification, CancellationToken cancellationToken)
        {
            // Aqui pode ser implementado um envio de e-mail, registro de log ou qualquer outra ação

            return Task.CompletedTask;
        }
    }
}
