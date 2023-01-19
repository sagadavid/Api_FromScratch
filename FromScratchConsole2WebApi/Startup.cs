using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FromScratchConsole2WebApi
{
    public class Startup
    {
        //services
        public void ConfigureServices(IServiceCollection services) 
        { 
            services.AddControllers();//only web api
            //services.AddMvc();//mvc for api, for razor pages and for web app
            //services.AddRazorPages();//only razorpages
        
        }

        //http request pipeline and environment
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) 
        {
            if (env.IsDevelopment()) { app.UseDeveloperExceptionPage(); }

            app.UseRouting();//just enabling routing, not calling endpoint

            app.UseEndpoints(endpoints =>
            {
                //addcontrollers sevice requires own route mapping. 
                //those below is empty template and self mapping. so, comment them.
                //and add mapcontrollers.

                endpoints.MapControllers();

                ////mapget allows exact url as endpoint
                //endpoints.MapGet("/", async context =>
                //await context.Response.WriteAsync("console app to web api, experimental nishi ")
                //);

                ////a second endpoit for educational purposes
                //endpoints.MapGet("/newurl", async context =>
                //await context.Response.WriteAsync("new url new message")
                //);
            });
        }
    }
}
