using Microsoft.EntityFrameworkCore;
using VinilSales.Repository.Domain.AlbumContext.Entities;

namespace VinilSales.Repository.AlbumContext.DbContexts
{
    public class AlbumDbContext : DbContext
    {
        public DbSet<AlbumEntity> Album { get; set; }
    }
}
