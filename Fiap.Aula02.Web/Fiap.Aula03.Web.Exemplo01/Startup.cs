using Fiap.Aula03.Web.Exemplo01.Persistencia;
using Fiap.Aula03.Web.Exemplo01.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Aula03.Web.Exemplo01
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

            //Configurar a inje��o de depend�ncia do DbContext
            services.AddDbContext<FiapFlixContext>(op => 
                op.UseSqlServer(Configuration.GetConnectionString("conexao")));

            //Configurar a inje��o de depend�ncia dos Repositories
            services.AddScoped<IFilmeRepository, FilmeRepository>();
            services.AddScoped<IAtorRepository, AtorRepository>();
            services.AddScoped<IProdutoraRepository, ProdutoraRepository>();
            services.AddScoped<IAtorFilmeRepository, AtorFilmeRepository>();

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
