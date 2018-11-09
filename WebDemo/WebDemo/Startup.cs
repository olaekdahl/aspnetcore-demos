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
using Microsoft.Extensions.Logging;
using WebDemo.Configs;
using WebDemo.DAL;
using WebDemo.Services;
using WebDemo.Shared.Models;

namespace WebDemo
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
            services.AddMvc();
            services.Configure<EmailOptions>(Configuration.GetSection("EmailSettings"));

            services.AddDbContext<AppDbContext>(options => 
               options.UseSqlServer(Configuration.GetConnectionString("Ecomm")));


            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddSingleton<IEmail, ProdEmail>();
            services.AddMemoryCache();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IEmail email, ILoggerFactory loggerFactory)
        {
            if(env.IsEnvironment("Development"))
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("~/Home/Exception");
            }
            //app.UseStatusCodePages();
            app.UseStatusCodePagesWithRedirects("~/Home/Error/{0}");
            app.UseStaticFiles();
            app.UseSession();
            //app.pages
            app.UseMvcWithDefaultRoute();
            //app.UseMvc(routes =>
            //    {
            //        routes.MapRoute("products", "products.php/{pid?}", new { controller="products", action="list" });
            //        routes.MapRoute("default", "{controller}/{action}/{id?}");
            //    }
            //);
            email.Send($"App configured {DateTime.Now}","ola@isinc.com");
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});
        }
    }
}
