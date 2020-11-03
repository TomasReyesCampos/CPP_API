using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore.SqlServer;
using CPP.Repository.Context;
using Microsoft.EntityFrameworkCore;
using CPP.Repository.Repository;
using AutoMapper;
using CPP.Repository.Interfaces;

namespace CPP.Api
{
    public class Startup
    {
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddMvc();
            services.AddDbContext<CPPContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("CPPEntity")));
           
            services.AddScoped<IFormaPagoRepository, FormaPagoRepository>();
            services.AddScoped<ITipoProveedorRepository, TipoProveedorRepository>();
            services.AddScoped<IProveedorRepository, ProveedorRepository>();
            services.AddScoped<ISucursalRepository, SucursalRepository>();
            services.AddScoped<IRemisionesRepository, RemisionRepository>();
            services.AddScoped<IDashboardRepository, DashboardRepository>();
            services.AddScoped<IBaseRepository, BaseRepository>();
            services.AddScoped<IOrdenesRepository, OrdenesRespository>();
            services.AddScoped<IReportesRepository, ReportesRepository>();

            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                  builder =>
                                  { 
                                      builder.AllowAnyOrigin()
                                              .AllowAnyMethod()
                                              .AllowAnyHeader();
                                  });
            });
       
            services.AddAutoMapper(typeof(Startup));

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
            app.UseCors(MyAllowSpecificOrigins);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
