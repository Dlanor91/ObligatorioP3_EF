using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.InterfacesRepositorio;
using Dominio.EntidadesVivero;
using LogicaDeAplicacion;
using Repositorios;
using Microsoft.EntityFrameworkCore;

namespace Vivero
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
            services.AddControllersWithViews();

            //para uso de sesiones
            services.AddSession();

            //servicios de repositorios
            services.AddScoped<IRepositorioTipoPlanta, RepositorioTipoPlantaEF>();
            services.AddScoped<IRepositorioUsuario, RepositorioUsuarioEF>();
            services.AddScoped<IRepositorioPlantas, RepositorioPlantaEF>();
            services.AddScoped<IRepositorioTipoAmbiente, RepositorioTipoAmbienteEF>();
            services.AddScoped<IRepositorioIluminacion, RepositorioIluminacionEF>();            
            

            //servicios de manejadoras  
            services.AddScoped<IManejadorTipoPlantas, ManejadorTipoPlantas>();
            services.AddScoped<IManejadorUsuario, ManejadorUsuario>();
            services.AddScoped<IManejadorTipoAmbiente, ManejadorTipoAmbiente>();
            services.AddScoped<IManejadorIluminacion, ManejadorIluminacion>();
            services.AddScoped<IManejadorPlanta, ManejadorPlanta>();

            //servicios para DbContext           
            
            services.AddDbContext<ViveroContext>
                (opciones => opciones
                            .UseSqlServer(Configuration.GetConnectionString("ConexionEF"))
                            .EnableSensitiveDataLogging());

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            //para uso de sesiones
            app.UseSession();
            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
