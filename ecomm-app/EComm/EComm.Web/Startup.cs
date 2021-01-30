using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EComm.Web.DAL;
using EComm.Web.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Diagnostics;

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
            services.AddTransient<IEmailService, SMTPEmailService>();
            services.AddTransient<IRepository, Repository>();

            services.AddRazorPages().AddRazorRuntimeCompilation();

            services.AddDbContext<ECommDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("EComm")));
            services.Configure<EmailOptions>(Configuration.GetSection("EmailSettings"));
            services.AddControllersWithViews();

            services.AddSession();
            services.AddMemoryCache();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.Use(async (context, next) =>
            {
                context.Items["isVerified"] = true;
                await next.Invoke();
            });

            app.UseStatusCodePages(async context =>
            {
                context.HttpContext.Response.ContentType = "text/html";

                await context.HttpContext.Response.WriteAsync(
                    $"(Custom) <b> code</b>: { context.HttpContext.Response.StatusCode }"
                );
            });

            app.UseStatusCodePagesWithRedirects("/Home/ClientError?id={0}");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {

                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
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
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            endpoints.MapControllerRoute(
                name: "add",
                pattern: "{controller=Shopping}/{action=Test}/{num1:int?}/{num2:alpha?}");

            endpoints.MapControllerRoute(
                name: "add2",
                pattern: "Test/{num1:int?}/{num2:alpha?}",
                defaults: new { controller = "Shopping", action = "Test" });

            });
        }
    }
}
