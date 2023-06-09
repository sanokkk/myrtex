using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using myrtex.DAL;
using myrtex.DAL.Interfaces;
using myrtex.DAL.Repos;
using myrtex.Domain.Models;

namespace myrtex.api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Добавление сервисов в DI
        /// </summary>
        public IConfiguration Configuration { get; }
        
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddRouting(r => r.LowercaseUrls = true);

            services.AddDbContext<ApplicationDbContext>(opt 
                =>opt.UseSqlServer(Configuration.GetConnectionString("SQL_Server")));

            services.AddScoped<IEmployeeRepo, EmployeeRepo>();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            

            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo(){Title = "Myrtex API", Version = "v1"});
            });
        }

        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(swagger =>
            {
                swagger.SwaggerEndpoint("/swagger/v1/swagger.json", "Myrtex API");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}