using MediatR;

namespace VinilSales.Application.PedidoContext.Notification
{
    public class PedidoCriadoNotification : INotification
    {
        public PedidoCriadoNotification(int idPedido)
        {
            this.IdPedido = idPedido;
        }

        public int IdPedido { get; set; }
    }
}
