using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace FromScratchConsole2WebApi
{
    public class Startup
    {
        //services
        public void ConfigureServices(IServiceCollection services) { }

        //http request pipeline and environment
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) { 
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {

                endpoints.MapGet("/", async context =>
                await context.Response.WriteAsync("console app to web api, experimental nishi ")
                );

                endpoints.MapGet("/newurl", async context =>
                await context.Response.WriteAsync("new url new message")
                );
            });
        }
    }
}
