using MediatR;

namespace VinilSales.Application.PedidoContext.Notification
{
    public class PedidoCanceladoNotification : INotification
    {
        public PedidoCanceladoNotification(int idPedido)
        {
            this.IdPedido = idPedido;
        }

        public int IdPedido { get; set; }
    }
}
