using Microsoft.EntityFrameworkCore;
using Vinil.Repository.Domain.AlbumContext.Entities;

namespace Vinil.Repository.AlbumContext.DbContexts
{
    public class AlbumDbContext : DbContext
    {
        public DbSet<AlbumEntity> Album { get; set; }
    }
}
