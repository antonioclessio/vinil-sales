using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VinilSales.Repository.CoreContext.Base;
using VinilSales.Repository.Domain.ProdutoContext.Entities;
using VinilSales.Repository.Domain.ProdutoContext.Interfaces;
using VinilSales.Repository.ProdutoContext.DbContexts;

namespace VinilSales.Repository.ProdutoContext.Repository
{
    public class ProdutoRepository : BaseRepository<ProdutoDbContext>, IProdutoRepository
    {
        public ProdutoRepository(ProdutoDbContext context) : base(context) { }

        public Task<List<ProdutoEntity>> GetAll()
        {
            var result = _dbContext.Produto.ToList();
            return Task.FromResult(result);
        }

        public Task<ProdutoEntity> GetByKeyAsync(int key)
        {
            return Task.FromResult(_dbContext.Produto.FirstOrDefault(a => a.IdProduto == key));
        }

        public Task<bool> Remove(int key)
        {
            var entity = _dbContext.Produto.FirstOrDefault(a => a.IdProduto == key);
            if (entity == null) return Task.FromResult(false);

            _dbContext.Produto.Remove(entity);
            _dbContext.SaveChanges();

            return Task.FromResult(true);
        }

        public Task<bool> AddRange(List<ProdutoEntity> list)
        {
            list.ForEach(item => _dbContext.Add(item));
            return Task.FromResult(_dbContext.SaveChanges() > 0);
        }

        public Task<bool> Save(ProdutoEntity model)
        {
            if (model.IdProduto == 0)
            {
                return Task.FromResult(Inserir(model));
            }

            return Task.FromResult(Atualizar(model));
        }

        private bool Inserir(ProdutoEntity model)
        {
            _dbContext.Produto.Add(model);
            return _dbContext.SaveChanges() > 0;
        }

        private bool Atualizar(ProdutoEntity model)
        {
            model.RegistrarAlteracao();

            _dbContext.Entry(model).State = EntityState.Modified;
            return _dbContext.SaveChanges() > 0;
        }
    }
}
