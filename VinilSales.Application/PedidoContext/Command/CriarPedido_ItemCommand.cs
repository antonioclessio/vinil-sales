using MediatR;
using VinilSales.Domain.ProdutoContext.Enum;

namespace VinilSales.Application.PedidoContext.Command
{
    public class CriarPedido_ItemCommand : IRequest<bool>
    {
        public CriarPedido_ItemCommand(int idPedido, int idProduto, int quantidade)
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
