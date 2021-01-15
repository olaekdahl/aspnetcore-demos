using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecomm.Data;
using Ecomm.Data.Repository;
using Ecomm.Web.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Diagnostics;
using System.IO;
using Ecomm.Web.Controllers;

namespace Ecomm.Web
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
            services.AddSingleton<IEmailService, EmailService>();

            services.AddDbContext<DemoDbCtx>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("connStr")));

            services.AddDbContext<ProductDbCtx>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("prodDb")));

            services.AddScoped<IRepository, Repository>();

            services.AddRazorPages().AddRazorRuntimeCompilation();

            services.AddMemoryCache();
            services.AddSession();

            services.AddGrpc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseExceptionHandler(errorApp =>
            {
                errorApp.Run(async context =>
                {
                    var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();
                    if (exceptionHandlerPathFeature != null)
                    {
                        // Get which route the exception occurred at
                        string routeWhereExceptionOccurred = exceptionHandlerPathFeature.Path;

                        // Get the exception that occurred
                        Exception exceptionThatOccurred = exceptionHandlerPathFeature.Error;

                        await context.Response.WriteAsync("Oh Oh!");
                    }
                });
            });

            //app.UseStatusCodePages();
            

            app.UseStatusCodePages(context =>
            {
                context.HttpContext.Response.ContentType = "text/html";

                return context.HttpContext.Response.WriteAsync(
                    $"(Custom) <b>Status code</b>: {context.HttpContext.Response.StatusCode}"
                    );
            });

            //app.UseStatusCodePagesWithRedirects("/error?code={0}");
            //app.UseStatusCodePagesWithReExecute("/error", "?code={0}");

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
                //endpoints.MapControllerRoute(
                //    name: "auth",
                //    pattern: "login/{gid:int}",
                //    defaults: new { controller="auth", action="login" });
                endpoints.MapGrpcService<GRpcDemo>();
                endpoints.MapControllerRoute(
                    name: "error",
                    pattern: "error",
                    defaults: new { controller = "error", action = "error" });
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
