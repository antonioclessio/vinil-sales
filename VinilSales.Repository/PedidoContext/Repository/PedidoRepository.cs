using System.Threading.Tasks;
using VinilSales.Repository.CoreContext.Base;
using VinilSales.Repository.Domain.PedidoContext.Entities;
using VinilSales.Repository.Domain.PedidoContext.Interfaces;
using VinilSales.Repository.PedidoContext.DbContexts;

namespace VinilSales.Repository.PedidoContext.Repository
{
    public class PedidoRepository : BaseRepository<PedidoDbContext>, IPedidoRepository
    {
        public PedidoRepository(PedidoDbContext context)
            : base(context)
        {
        }

        public Task<bool> AdicionarItem(Pedido_ItemEntity model)
        {
            _dbContext.Pedido_Item.Add(model);
            return Task.FromResult(_dbContext.SaveChanges() > 0);
        }

        public Task<bool> Finalizar(int idPedido)
        {
            return Task.FromResult(_dbContext.SaveChanges() > 0);
        }

        public Task<bool> Salvar(PedidoEntity model)
        {
            _dbContext.Add(model);

            model.Itens.ForEach(item => _dbContext.Add(item));

            return Task.FromResult(_dbContext.SaveChanges() > 0);
        }
    }
}
