namespace VinilSales.Repository.CoreContext.Base
{
    public abstract class BaseRepository<TContext>
    {
        protected TContext _dbContext { get; }

        public BaseRepository(TContext context)
        {
            this._dbContext = context;
        }
    }
}
