using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CorsiOnline.Models;
using CorsiOnline.Models.Database;
using CorsiOnline.Models.Core;
using CorsiOnline.Models.Core.UnitOfWorks;
using CorsiOnline.Models.UnitOfWorks;

namespace FinsaWeb
{
    public class Startup
    {
        
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ContestoCorso>(opts => opts.UseSqlServer(
               Configuration.GetConnectionString("DefaultConnection")));
            //services.AddSingleton<IRepositoryCorsi, RepositoryCorsiTest>();
            services.AddTransient<IRepositoryCorsi, RepositoryCorsi>();
            services.AddTransient<IDocentiRepository, RepositoryDocenti>();
            services.AddTransient<IStudenteRepository, RepositoryStudenti>();
            services.AddTransient<IAulaRepository, AulaRepository>();
            services.AddTransient<IUnitOfWorkCorsi, EFUnitOfWorkCorsi>();
            services.AddTransient<IUnitOfWorkStudenti, EFUnitOfWorkStudenti>();
            services.AddTransient<IUnitOfWorkDocenti, EFUnitOfWorkDocenti>();
            services.AddTransient<IUnitOfWorkAule, EFUnitOfWorkAule>();
            services.AddMvc();
            services.AddCors();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseCors(builder =>
            builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
