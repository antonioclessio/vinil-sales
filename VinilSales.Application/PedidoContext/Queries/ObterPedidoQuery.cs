using MediatR;
using VinilSales.Application.PedidoContext.Results;

namespace VinilSales.Application.PedidoContext.Queries
{
    public class ObterPedidoQuery : IRequest<ObterPedidoResult>
    {
        public ObterPedidoQuery(int idPedido)
        {
            this.IdPedido = idPedido;
        }

        public int IdPedido { get; set; }
    }
}
