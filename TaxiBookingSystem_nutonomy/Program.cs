using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace TaxiBookingSystem_nutonomy
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //BuildWebHost(args).Run();

            Console.Title = "API Backend Server";

            var host = new WebHostBuilder()
                         .UseKestrel((options) =>
                         {
                             options.Limits.KeepAliveTimeout = new System.TimeSpan(0, 3, 0);
                             options.Limits.MaxConcurrentConnections = 1000;
                         })
                         .UseUrls("http://*:8080;http://localhost:8080;")
                         .UseContentRoot(Directory.GetCurrentDirectory())
                         .UseSetting("detailedErrors", "true")
                         .UseIISIntegration()
                         .UseStartup<Startup>()
                         .CaptureStartupErrors(true)
                         .Build();
            host.Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
