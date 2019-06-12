using MediatR;

namespace VinilSales.Application.PedidoContext.Command
{
    public class FinalizarPedidoCommand : IRequest<bool>
    {
        public FinalizarPedidoCommand(int idPedido)
        {
            this.IdPedido = idPedido;
        }

        public int IdPedido { get; set; }
    }
}
