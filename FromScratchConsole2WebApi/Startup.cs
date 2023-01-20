using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;

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
            //middlewares!

            app.Use(async (context, next) =>
            { 
                await context.Response.WriteAsync("this is app.use 1 1 \n"); 
                //if next not used, doesnt skip to another middleware, dvs app.run
                await next();
                await context.Response.WriteAsync("this is app.use 1 2 \n");
            });
 
            //if mapping matches the route then funcs as a branch,
            //after customresponse mehtod backwards cause has no next
            app.Map("/saga", CustomResponse);//could be index as.. app.Map("", CustomResponse);
            
            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("this is app.use 2 1 \n");
                await next();
                await context.Response.WriteAsync("this is app.use 2 2 \n");
            });
            
           

            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("app.use without next,\n" +
                    "designed as completer/backwardssender (instead of app.run) \n");
            });

            //need to pass in requestdelegate
            app.Run(async context =>
            {
                //if the first run is not commented, it terminates pipline
                //and 2nd run doesnt work,pipeline returns backwards and goes on
                await context.Response.WriteAsync("this is app.run 1\n");
            });

            
            app.Run(async context =>
            {
                await context.Response.WriteAsync("this is app.run 2\n");
            });

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

        private void CustomResponse(IApplicationBuilder app)
        {
            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("response from mapped" +
                    " customcode of route of /saga \n");
            });
        }
    }
}
