using System.Collections.Generic;
using System.Threading.Tasks;

namespace VinilSales.Repository.Domain.CoreContext.Interfaces
{
    public interface IRepository<TEntity>
    {
        Task<bool> Remove(int key);

        Task<bool> Save(TEntity model);

        Task<List<TEntity>> GetAll();

        Task<TEntity> GetByKeyAsync(int key);
    }
}
