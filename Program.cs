using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace poptwit
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = BuildWebHost(args);
            BuildDatabase(host);
            host.Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .Build();

        public static void BuildDatabase(IWebHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var service = scope.ServiceProvider;
                try
                {
                    var context = service.GetRequiredService<PopContext>();
                    DbInitializer.Initialize(context);
                }
                catch (Exception e)
                {
                    Console.WriteLine($"An error occurred while setting up the database: {e.Message}");
                }
            }
        }
    }
}
