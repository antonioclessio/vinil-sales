using Microsoft.EntityFrameworkCore;
using VinilSales.Repository.Domain.PedidoContext.Entities;

namespace VinilSales.Repository.PedidoContext.DbContexts
{
    public class PedidoDbContext : DbContext
    {
        public PedidoDbContext(DbContextOptions<PedidoDbContext> options) : base(options) { }

        public DbSet<PedidoEntity> Pedido { get; set; }
    }
}
