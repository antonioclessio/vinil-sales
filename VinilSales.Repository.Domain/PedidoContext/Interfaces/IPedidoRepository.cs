using System.Threading.Tasks;
using VinilSales.Repository.Domain.PedidoContext.Entities;

namespace VinilSales.Repository.Domain.PedidoContext.Interfaces
{
    public interface IPedidoRepository
    {
        Task<bool> Salvar(PedidoEntity model);
        Task<bool> AdicionarItem(Pedido_ItemEntity model);
        Task<bool> Finalizar(int idPedido);
    }
}
