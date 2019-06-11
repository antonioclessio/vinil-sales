using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using VinilSales.Domain.ProdutoContext.Enum;
using VinilSales.Repository.CoreContext.Base;
using VinilSales.Repository.Domain.TabelaCashbackContext.Entities;
using VinilSales.Repository.Domain.TabelaCashbackContext.Interfaces;
using VinilSales.Repository.TabelaCashbackContext.DbContexts;

namespace VinilSales.Repository.TabelaCashbackContext.Repository
{
    public class TabelaCashbackRepository : BaseRepository<TabelaCashbackDbContext>, ITabelaCashbackRepository
    {
        public TabelaCashbackRepository(TabelaCashbackDbContext context) 
            : base(context)
        {
            adicionarDadosMock();
        }

        private void adicionarDadosMock()
        {
            if (_dbContext.TabelaCashback.ToList().Count > 0) { return; }

            _dbContext.TabelaCashback.Add(
                new TabelaCashbackEntity
                {
                    IdTabelaCashback = 1,
                    DataInicioVigencia = DateTime.Now,
                    Observacao = "Tabela vigente"
                });

            _dbContext.TabelaCashback_Item.Add(
                new TabelaCashback_ItemEntity
                {
                    IdTabelaCashbackItem = 1,
                    IdTabelaCashback = 1,
                    Genero = (byte)GeneroEnum.Pop,
                    Domingo = 25,
                    Segunda = 7,
                    Terca = 6,
                    Quarta = 2,
                    Quinta = 10,
                    Sexta = 15,
                    Sabado = 20
                });

            _dbContext.TabelaCashback_Item.Add(
                new TabelaCashback_ItemEntity
                {
                    IdTabelaCashbackItem = 2,
                    IdTabelaCashback = 1,
                    Genero = (byte)GeneroEnum.MPB,
                    Domingo = 30,
                    Segunda = 5,
                    Terca = 10,
                    Quarta = 15,
                    Quinta = 20,
                    Sexta = 25,
                    Sabado = 30
                });

            _dbContext.TabelaCashback_Item.Add(
                new TabelaCashback_ItemEntity
                {
                    IdTabelaCashbackItem = 3,
                    IdTabelaCashback = 1,
                    Genero = (byte)GeneroEnum.Classico,
                    Domingo = 35,
                    Segunda = 3,
                    Terca = 5,
                    Quarta = 8,
                    Quinta = 13,
                    Sexta = 18,
                    Sabado = 25
                });

            _dbContext.TabelaCashback_Item.Add(
                new TabelaCashback_ItemEntity
                {
                    IdTabelaCashbackItem = 4,
                    IdTabelaCashback = 1,
                    Genero = (byte)GeneroEnum.Pop,
                    Domingo = 40,
                    Segunda = 10,
                    Terca = 15,
                    Quarta = 15,
                    Quinta = 15,
                    Sexta = 20,
                    Sabado = 40
                });

            _dbContext.SaveChanges();
        }

        public Task<TabelaCashbackEntity> ObterTabelaVigente()
        {
            var entity = _dbContext.TabelaCashback
                                   .Where(a => a.DataInicioVigencia.Date <= DateTime.Now.Date)
                                   .OrderByDescending(a => a.DataInicioVigencia)
                                   .Include(a => a.Itens)
                                   .FirstOrDefault();

            return Task.FromResult(entity);
        }
    }
}
