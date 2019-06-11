using System;
using System.Linq;
using VinilSales.Repository.CoreContext.Base;
using VinilSales.Repository.Domain.TabelaCashbackContext.Entities;
using VinilSales.Repository.Domain.TabelaCashbackContext.Interfaces;
using VinilSales.Repository.TabelaCashbackContext.DbContexts;

namespace VinilSales.Repository.TabelaCashbackContext.Repository
{
    public class TabelaCashbackRepository : BaseRepository<TabelaCashbackDbContext>, ITabelaCashbackRepository
    {
        public TabelaCashbackRepository(TabelaCashbackDbContext context) : base(context) { }

        public TabelaCashbackEntity ObterTabelaVigente()
        {
            var entity = _dbContext.TabelaCashback
                                   .Where(a => a.DataInicioVigencia <= DateTime.Now)
                                   .OrderByDescending(a => a.DataInicioVigencia)
                                   .FirstOrDefault();

            if (entity == null) return null;
            entity.Itens.AddRange(_dbContext.TabelaCashback_Item.Where(a => a.IdTabelaCashback == entity.IdTabelaCashback));

            return entity;
        }
    }
}
