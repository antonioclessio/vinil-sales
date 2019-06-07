namespace VinilSales.Repository.Domain.CoreContext.Interfaces
{
    public interface IRepository<TEntity>
    {
        bool Remove(int key);

        bool Save(TEntity model);

        TEntity GetByKeyAsync(int key);
    }
}
