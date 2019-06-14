using MediatR;

namespace VinilSales.Application.PedidoContext.Notification
{
    public class PedidoFinalizadoNotification : INotification
    {
        public PedidoFinalizadoNotification(int idCliente, int idPedido, decimal valorPedido, decimal valorTransacao)
        {
            this.IdCliente = idCliente;
            this.IdPedido = idPedido;
            this.ValorPedido = valorPedido;
            this.ValorTransacao = valorTransacao;
        }

        public int IdCliente { get; set; }

        public int IdPedido { get; set; }

        public decimal ValorPedido { get; set; }

        public decimal ValorTransacao { get; set; }
    }
}
