using ArtHub.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtHub
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // add code to update DB using configureDbContext

            var host = CreateHostBuilder(args).Build();
            UpdateDatabase(host.Services);
            host.Run();
        }

        // code to update Db. Using is an override
        private static void UpdateDatabase(IServiceProvider services)
        {
            using (var serviceScope = services.CreateScope())
            {
                using (var db = serviceScope.ServiceProvider.GetService<ArtHubDbContext>())
                {
                    db.Database.Migrate();
                }
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
