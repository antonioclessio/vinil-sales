using MediatR;

namespace VinilSales.Application.PedidoContext.Command
{
    public class CancelarPedidoCommand : IRequest<bool>
    {
        public CancelarPedidoCommand(int idPedido)
        {
            this.IdPedido = idPedido;
        }

        public int IdPedido { get; set; }
    }
}
