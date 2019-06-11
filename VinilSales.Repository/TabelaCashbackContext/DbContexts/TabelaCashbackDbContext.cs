using Microsoft.EntityFrameworkCore;
using System;
using VinilSales.Domain.ProdutoContext.Enum;
using VinilSales.Repository.Domain.TabelaCashbackContext.Entities;

namespace VinilSales.Repository.TabelaCashbackContext.DbContexts
{
    public class TabelaCashbackDbContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TabelaCashbackEntity>().HasData(
                new TabelaCashbackEntity {
                    DataInicioVigencia = DateTime.Now,
                    Observacao = "Tabela vigente"
                });

            modelBuilder.Entity<TabelaCashback_ItemEntity>().HasData(
                new TabelaCashback_ItemEntity
                {
                    IdTabelaCashback = 1,
                    Genero = (byte)GeneroEnum.Classico,
                    Segunda = 1,
                    Terca = 2,
                    Quarta = 3,
                    Quinta = 4,
                    Sexta = 5,
                    Sabado = 6,
                    Domingo = 7
                });

            modelBuilder.Entity<TabelaCashback_ItemEntity>().HasData(
                new TabelaCashback_ItemEntity
                {
                    IdTabelaCashback = 1,
                    Genero = (byte)GeneroEnum.Pop,
                    Segunda = 1,
                    Terca = 2,
                    Quarta = 3,
                    Quinta = 4,
                    Sexta = 5,
                    Sabado = 6,
                    Domingo = 7
                });

            modelBuilder.Entity<TabelaCashback_ItemEntity>().HasData(
                new TabelaCashback_ItemEntity
                {
                    IdTabelaCashback = 1,
                    Genero = (byte)GeneroEnum.Rock,
                    Segunda = 1,
                    Terca = 2,
                    Quarta = 3,
                    Quinta = 4,
                    Sexta = 5,
                    Sabado = 6,
                    Domingo = 7
                });

            modelBuilder.Entity<TabelaCashback_ItemEntity>().HasData(
                new TabelaCashback_ItemEntity
                {
                    IdTabelaCashback = 1,
                    Genero = (byte)GeneroEnum.MPB,
                    Segunda = 1,
                    Terca = 2,
                    Quarta = 3,
                    Quinta = 4,
                    Sexta = 5,
                    Sabado = 6,
                    Domingo = 7
                });
        }

        public TabelaCashbackDbContext(DbContextOptions<TabelaCashbackDbContext> options) : base(options) { }

        public DbSet<TabelaCashbackEntity> TabelaCashback { get; set; }

        public DbSet<TabelaCashback_ItemEntity> TabelaCashback_Item { get; set; }
    }
}
