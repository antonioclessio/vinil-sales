using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;

namespace VinilSales.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Vinil Sales", Version = "v1" });
            });

            initDependencyInjection(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            defineEnvironment(app, env);
            initSwagger(app);
            
            app.UseHttpsRedirection();
            app.UseMvc();
        }

        private void defineEnvironment(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
        }

        private void initSwagger(IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Vinil Sales");
            });
            app.UseWelcomePage("/swagger");
        }

        private void initDependencyInjection(IServiceCollection services)
        {
            Application.Bootstrap.ConfigureDependencyInjection(ref services);

            var assemblies = new List<Assembly>();
            assemblies.Add(AppDomain.CurrentDomain.Load("VinilSales.WebAPI"));
            assemblies.Add(AppDomain.CurrentDomain.Load("VinilSales.Application"));

            services.AddMediatR(assemblies.ToArray());
        }
    }
}
