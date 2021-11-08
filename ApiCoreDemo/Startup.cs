using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiCoreDemo.ActionFilter1;
using ApiCoreDemo.Models;
using ApiCoreDemo.Repository;
using ApiCoreDemo.Repository.IRepository;
using ApiCoreDemo.Service;
using ApiCoreDemo.Service.IService;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ApiCoreDemo
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
            services.AddDbContext<EFDATAContext>(options => options.UseSqlServer(Configuration.GetConnectionString("EFDatabase")));
            services.AddControllers().AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null); //�^��Json�������j�p�g�@�P
            //services.AddScoped<IBirthDayRepository, BirthDayRepository>();
            services.AddScoped<IBirthDayCityRepository, BirthDayCityRepository>();
            services.AddScoped<IBirthdayCityService, BirthdayCityService>();
            //services.AddControllers(options =>
            //{
            //    options.AddMessageFilter();
            //});
            services.AddScoped<AuthorizationFilter>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
