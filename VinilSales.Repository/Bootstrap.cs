using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using VinilSales.Repository.AlbumContext.DbContexts;
using VinilSales.Repository.ClienteContext.DbContexts;

namespace VinilSales.Repository
{
    public static class Bootstrap
    {
        private const string DatabaseName = "VinilSales";

        public static void ConfigureDependencyInjection(ref IServiceCollection services)
        {
            services.AddDbContext<AlbumDbContext>(opt => opt.UseInMemoryDatabase(DatabaseName));
            services.AddDbContext<ClienteDbContext>(opt => opt.UseInMemoryDatabase(DatabaseName));
        }
    }
}
