using Microsoft.Extensions.DependencyInjection;
using VinilSales.Repository.ClienteContext.Repository;
using VinilSales.Repository.Domain.ClienteContext.Interfaces;

namespace VinilSales.Application
{
    public static class Bootstrap
    {
        public static void ConfigureDependencyInjection(ref IServiceCollection services)
        {
            Repository.Bootstrap.ConfigureDependencyInjection(ref services);

            services.AddTransient<IClienteRepository, ClienteRepository>();
        }
    }
}
