using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using WebApi.Store;
using WebApi.Core;
using Microsoft.EntityFrameworkCore;
//using webapiassignment;

namespace webapiassignment
{  public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var migrationAssemblyName = typeof(Startup).Assembly.FullName;
            var connectionString = Configuration.GetConnectionString("DefaultConnection");

            services
               .AddTransient<Istudentmembershipservice,studentmembershipservice>()
               .AddTransient<Ilibraryservice, libraryservice>();
            services
                .AddTransient<Ibookservices, bookservice>()
                .AddTransient<Ibookrespiratory, bookrespiratory>();
            services
                .AddTransient<Istudentbookrespiratory, studentbookrespiratory>()
                .AddTransient<Istudentrespiratory, studentrespiratory>()
                .AddTransient<unitofwork>(x => new unitofwork(connectionString, migrationAssemblyName))
            .AddTransient<librarycontext>(x => new librarycontext(connectionString, migrationAssemblyName));

            services.AddDbContext<librarycontext>(x => x.UseSqlServer(connectionString, m => m.MigrationsAssembly(migrationAssemblyName)));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
