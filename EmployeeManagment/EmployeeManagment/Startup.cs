using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagment.Controllers;
using EmployeeManagment.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagment
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services) //DI container
        {
            services.AddSingleton<IEmployeeRepository, MockEmployeeRepository>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2).AddXmlSerializerFormatters();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILogger<Startup> logger)
        {
            if (env.IsDevelopment()) // da bide fuknat sto e porano za da go koristime odma bez nego nema stacktrace
            {
                //var developerExceptionPageOptions = new DeveloperExceptionPageOptions();
                //developerExceptionPageOptions.SourceCodeLineCount = 10;

                app.UseDeveloperExceptionPage();
            }
            //app.Use(async (context, next) =>
            //{
            //    logger.LogInformation("MW1: Incoming Request");
            //    await next();
            //    logger.LogInformation("MW1: Outgoing Request");
            //});

            //app.Use(async (context, next) =>
            //{
            //    logger.LogInformation("MW2: Incoming Request");
            //    await next();
            //    logger.LogInformation("MW2: Outgoing Request");
            //});

            //var defaultFilesOptions = new DefaultFilesOptions(); //za staticni fajlovi
            //var fileServerOptions = new FileServerOptions();
            //fileServerOptions.DefaultFilesOptions.DefaultFileNames.Clear();
            //fileServerOptions.DefaultFilesOptions.DefaultFileNames.Add("food.html");
            //app.UseDefaultFiles(defaultFilesOptions); 
            app.UseStaticFiles();
            //app.UseFileServer();

            //app.UseMvcWithDefaultRoute();

            app.UseMvc(routes =>
            {
                routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });

            //app.UseMvc();

            app.Run(async (context) => //Terminal MIddleware
            {
                //throw new Exception("Some Error Processing the request ");
                //await context.Response.WriteAsync(System.Diagnostics.Process.GetCurrentProcess().ProcessName);
                //await context.Response.WriteAsync("MW3: Request handled and responce produced!");

                await context.Response.WriteAsync("HELLO WORLD!");
                // logger.LogInformation("MW3: Request handled and responce produced!");
            });
        }
    }
}
