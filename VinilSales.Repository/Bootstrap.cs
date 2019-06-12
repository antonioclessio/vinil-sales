using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using VinilSales.Repository.ClienteContext.DbContexts;
using VinilSales.Repository.PedidoContext.DbContexts;
using VinilSales.Repository.ProdutoContext.DbContexts;
using VinilSales.Repository.TabelaCashbackContext.DbContexts;

namespace VinilSales.Repository
{
    public static class Bootstrap
    {
        private const string DatabaseName = "VinilSales";

        public static void ConfigureDependencyInjection(ref IServiceCollection services)
        {
            services.AddDbContext<PedidoDbContext>(opt => opt.UseInMemoryDatabase(DatabaseName));
            services.AddDbContext<TabelaCashbackDbContext>(opt => opt.UseInMemoryDatabase(DatabaseName));
            services.AddDbContext<ProdutoDbContext>(opt => opt.UseInMemoryDatabase(DatabaseName));
            services.AddDbContext<ClienteDbContext>(opt => opt.UseInMemoryDatabase(DatabaseName));
        }
    }
}
