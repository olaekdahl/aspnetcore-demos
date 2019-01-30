using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace DemoApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args).ConfigureAppConfiguration((hostingContext, config) =>
            {
                //config.AddJsonFile("mysettings.json",
                //                   optional: false, reloadOnChange: false);
                //config.AddXmlFile("othersettings.xml",
                //                  optional: false, reloadOnChange: false);
                //config.AddCommandLine(args);
            })
        .UseStartup<Startup>();
    }
}
