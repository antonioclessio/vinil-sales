﻿using Microsoft.Extensions.DependencyInjection;
using VinilSales.Application.CoreContext;
using VinilSales.Domain.CoreContext.Interfaces;
using VinilSales.Repository.ClienteContext.Repository;
using VinilSales.Repository.Domain.ClienteContext.Interfaces;
using VinilSales.Repository.Domain.PedidoContext.Interfaces;
using VinilSales.Repository.Domain.ProdutoContext.Interfaces;
using VinilSales.Repository.Domain.TabelaCashbackContext.Interfaces;
using VinilSales.Repository.PedidoContext.Repository;
using VinilSales.Repository.ProdutoContext.Repository;
using VinilSales.Repository.TabelaCashbackContext.Repository;

namespace VinilSales.Application
{
    public static class Bootstrap
    {
        public static void ConfigureDependencyInjection(ref IServiceCollection services)
        {
            Repository.Bootstrap.ConfigureDependencyInjection(ref services);

            ConfigureCoreDependencies(ref services);
            ConfigureBusinessDependencies(ref services);
        }

        private static void ConfigureCoreDependencies(ref IServiceCollection services)
        {
            services.AddScoped<IValidationMessage, ValidationMessage>();
        }

        private static void ConfigureBusinessDependencies(ref IServiceCollection services)
        {
            services.AddTransient<IPedidoRepository, PedidoRepository>();
            services.AddTransient<ITabelaCashbackRepository, TabelaCashbackRepository>();
            services.AddTransient<IProdutoRepository, ProdutoRepository>();
            services.AddTransient<IClienteRepository, ClienteRepository>();
        }
    }
}
