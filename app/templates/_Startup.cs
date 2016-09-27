using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace WebApplication
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();
            app.UseStaticFiles();
            app.UseSession();

            // When you run the app and don’t supply any URL segments,
            // it defaults to the “Home” controller and the “Index” method
            // specified in the template line below
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{action}",
                    defaults: new {controller = "Home", action = "Index"}
                );
            });
        }
    }
}
