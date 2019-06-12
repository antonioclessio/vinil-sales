using System.Collections.Generic;
using System.Threading.Tasks;

namespace VinilSales.Repository.Domain.CoreContext.Interfaces
{
    public interface IRepository<TEntity>
    {
        Task<bool> Remover(int key);

        Task<bool> Salvar(TEntity model);

        Task<List<TEntity>> ObterTodos();

        Task<TEntity> ObterPorId(int id);
    }
}
