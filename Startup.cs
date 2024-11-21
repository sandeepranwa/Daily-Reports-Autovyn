using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace ConsoleToWebApi
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddTransient<CustomMiddleware1>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            //app.Run(async context =>
            //{
            //    await context.Response.WriteAsync("Hello from run first");
            //});

            app.Use(async (context,next) =>
            {
                await context.Response.WriteAsync("Hello from run Use-1 1\n");
                await next();

                await context.Response.WriteAsync("Hello from run Use-1 2\n");
            });

            app.UseMiddleware<CustomMiddleware1>();

            app.Map("/testmode", CoutomCode);

            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("Hello from run Use-3 1\n");
                await next();

                await context.Response.WriteAsync("Hello from run Use-3 2\n");
            });

            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("Respond send succesfully!!\n");
                
            });

            //app.Run(async context =>
            //{
            //    await context.Response.WriteAsync("Hello from run Second\n");
            //});

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseRouting(); 

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapGet("/", async context =>
                //{
                //    await context.Response.WriteAsync("hello from new Web API");
                //});

                // endpoints.MapGet("/test", async context =>
                // {
                //     await context.Response.WriteAsync("hello from new Web API test mode");
                // });


                endpoints.MapControllers(); 
            } );
    }

        private void CoutomCode(IApplicationBuilder app)
        {
            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("testmode is Respond send succesfully!!\n");

            });
        }

     
    }
}
