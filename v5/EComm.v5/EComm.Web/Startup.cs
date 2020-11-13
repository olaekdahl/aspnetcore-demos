using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EComm.Web.Models;
using EComm.Web.Options;
using EComm.Web.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace EComm.Web
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
            services.AddTransient<IEmailService, EmailServiceImpl>();
            services.Configure<EmailOptions>(Configuration.GetSection("EmailSettings"));
            services.AddRazorPages().AddRazorRuntimeCompilation();


            services.AddDbContext<ECommDbContext>(
                options => options.UseSqlServer(
                    Configuration.GetConnectionString("ecommCon")));
            services.AddDbContext<InventoryDbContext>(
                options => options.UseSqlServer(
                    Configuration.GetConnectionString("inventory")));

            services.AddTransient<IRepository, Repository>();

            services.AddMemoryCache();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.Use(async (context, next) => {
                // perform some verification    
                context.Items["isVerified"] = true;
                context.Items["item2"] = "foo";
                await next.Invoke();
            });

            // app.UseStatusCodePages();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else if (env.IsEnvironment("QA"))
            {
                //do something in QA...
            }
            else
            {
                app.UseExceptionHandler("/Products/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseSerilogRequestLogging();
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Products}/{action=Index}/{id?}");
                //endpoints.MapControllerRoute(
                //   name: "login",
                //   pattern: "login",
                //   defaults: new { controller = "login", action = "LoginOathClient" });
            });
        }
    }
}
