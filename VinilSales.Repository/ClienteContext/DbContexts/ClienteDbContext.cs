using Microsoft.EntityFrameworkCore;
using VinilSales.Repository.Domain.ClienteContext.Entities;

namespace VinilSales.Repository.ClienteContext.DbContexts
{
    public class ClienteDbContext : DbContext
    {
        public ClienteDbContext(DbContextOptions<ClienteDbContext> options) : base(options) { }

        public DbSet<ClienteEntity> Cliente { get; set; }
    }
}
