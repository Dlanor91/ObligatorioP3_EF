using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.InterfacesRepositorio;
using Dominio.EntidadesVivero;
using LogicaDeAplicacion;
using Repositorios;
using Microsoft.EntityFrameworkCore;

namespace Vivero.WebAPI
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
            services.AddControllers();

            services.AddDbContext<ViveroContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ConexionEF")));

            services.AddScoped<IRepositorioCompra, RepositorioCompraEF>();
            services.AddScoped<IRepositorioPlantas, RepositorioPlantaEF>();
            services.AddScoped<IRepositorioItems, RepositorioItemsEF>();

            services.AddScoped<IManejadorCompra, ManejadorCompra>();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
