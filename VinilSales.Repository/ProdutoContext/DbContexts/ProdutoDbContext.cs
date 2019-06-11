using Microsoft.EntityFrameworkCore;
using VinilSales.Repository.Domain.ProdutoContext.Entities;

namespace VinilSales.Repository.ProdutoContext.DbContexts
{
    public class ProdutoDbContext : DbContext
    {
        public ProdutoDbContext(DbContextOptions<ProdutoDbContext> options) : base(options) { }

        public DbSet<ProdutoEntity> Produto { get; set; }
    }
}
