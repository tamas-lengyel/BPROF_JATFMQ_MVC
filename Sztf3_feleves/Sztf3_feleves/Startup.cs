using System;
using System.Collections.Generic;
using System.Linq;
using Logic;
using Repository;
using Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Sztf3_feleves
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(opt => opt.EnableEndpointRouting = false);

            services.AddTransient<RentersLogic, RentersLogic>();
            services.AddTransient<CarsLogic, CarsLogic>();
            services.AddTransient<SalonsLogic, SalonsLogic>();
            services.AddTransient<StatsLogic, StatsLogic>();
            services.AddTransient<IRepository<Renters>, RentersRepository>();
            services.AddTransient<IRepository<Cars>, CarsRepository>();
            services.AddTransient<IRepository<Salons>, SalonsRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseMvcWithDefaultRoute();

            app.UseRouting();

        }
    }
}
