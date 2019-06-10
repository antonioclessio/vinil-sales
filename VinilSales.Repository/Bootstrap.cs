using Microsoft.Extensions.DependencyInjection;
using VinilSales.Repository.ClienteContext.DbContexts;

namespace VinilSales.Repository
{
    public static class Bootstrap
    {
        public static void ConfigureDependencyInjection(ref IServiceCollection services)
        {
            services.AddDbContext<ClienteDbContext>();
        }
    }
}
