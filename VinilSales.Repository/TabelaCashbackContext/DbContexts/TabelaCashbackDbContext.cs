using Microsoft.EntityFrameworkCore;
using System;
using VinilSales.Domain.ProdutoContext.Enum;
using VinilSales.Repository.Domain.TabelaCashbackContext.Entities;

namespace VinilSales.Repository.TabelaCashbackContext.DbContexts
{
    public class TabelaCashbackDbContext : DbContext
    {
        public TabelaCashbackDbContext(DbContextOptions<TabelaCashbackDbContext> options) 
            : base(options) {}

        public DbSet<TabelaCashbackEntity> TabelaCashback { get; set; }

        public DbSet<TabelaCashback_ItemEntity> TabelaCashback_Item { get; set; }
    }
}
