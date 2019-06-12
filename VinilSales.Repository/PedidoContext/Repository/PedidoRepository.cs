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

        public void Salvar(PedidoEntity model)
        {
            _dbContext.Add(model);
            _dbContext.SaveChanges();
        }
    }
}
