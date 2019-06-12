using MediatR;

namespace VinilSales.Application.PedidoContext.Command
{
    public class AdicionarItemAoPedidoCommand : IRequest<bool>
    {
        public AdicionarItemAoPedidoCommand(int idPedido, int idProduto, int quantidade)
        {
            this.IdPedido = idPedido;
            this.IdProduto = idProduto;
            this.Quantidade = quantidade;
        }

        public int IdPedido { get; set; }

        public int IdProduto { get; set; }
        public int Quantidade { get; set; }
    }
}
