using System.Collections.Generic;
using System.Threading.Tasks;
using VinilSales.Repository.Domain.PedidoContext.Entities;

namespace VinilSales.Repository.Domain.PedidoContext.Interfaces
{
    public interface IPedidoRepository
    {
        Task<int> CriarPedido(PedidoEntity model);
        Task<bool> AdicionarItem(Pedido_ItemEntity model);
        Task<bool> FinalizarPedido(int idPedido);
        Task<bool> CancelarPedido(int idPedido);
        Task<PedidoEntity> ObterPorId(int idPedido);
        Task<List<PedidoEntity>> ObterPorFiltro(int idCliente);
    }
}
