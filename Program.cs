using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;

namespace ConsoleToWebApi
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateHostBuilder().Build().Run();
        }

        public static IHostBuilder CreateHostBuilder() =>
             Host.CreateDefaultBuilder()
                .ConfigureWebHostDefaults(webHost =>
            {
                webHost.UseStartup<Startup>();
            });

    }
}
 