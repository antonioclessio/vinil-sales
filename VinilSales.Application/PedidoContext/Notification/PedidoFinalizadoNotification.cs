using MediatR;

namespace VinilSales.Application.PedidoContext.Notification
{
    public class PedidoFinalizadoNotification : INotification
    {
        public PedidoFinalizadoNotification(int idPedido)
        {
            this.IdPedido = idPedido;
        }

        public int IdPedido { get; set; }
    }
}
