using VinilSales.Repository.Domain.PedidoContext.Entities;

namespace VinilSales.Repository.Domain.PedidoContext.Interfaces
{
    public interface IPedidoRepository
    {
        void Salvar(PedidoEntity model);
    }
}
