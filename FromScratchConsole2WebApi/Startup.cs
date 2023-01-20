using FromScratchConsole2WebApi.Controllers;
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
            services.AddTransient<SeperateFileMiddleware1>();//custom middleware class requires dependency injection.
        
        }

        //http request pipeline and environment
        public async void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            /*
             MIDDLEWARE
            */

            /*
             * //this section is about middleware flow..
             * //this section is commented for the sake of endpointRouting
             * 
            app.Use(async (context, next) =>
            { 
                await context.Response.WriteAsync("response from app.use 1 1 \n"); 
                //if next not used, doesnt skip to another middleware, dvs app.run
                await next();
                await context.Response.WriteAsync("response from app.use 1 2 \n");
            });
 
            //if mapping matches the route then funcs as a branch,
            //after customresponse mehtod backwards cause has no next
            app.Map("/saga", BuiltinMiddleware);//could be index as.. app.Map("", BuiltinMiddleware);
            
            app.UseMiddleware<SeperateFileMiddleware1>();

            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("response from app.use 2 1 \n");
                await next();
                await context.Response.WriteAsync("response from app.use 2 2 \n");
            });
           
            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("response from app.use without next()\n" +
                    "--> designed to complete and backward (instead of app.run) \n");
            });

            //need to pass in requestdelegate
            app.Run(async context =>
            {
                //if the first run is not commented, it terminates pipline
                //and 2nd run doesnt work,pipeline returns backwards and goes on
                await context.Response.WriteAsync("response from app.run 1\n");
            });

            app.Run(async context =>
            {
                await context.Response.WriteAsync("response from app.run 2\n");
            });

            if (env.IsDevelopment()) { app.UseDeveloperExceptionPage(); }
            
             */

            /* 
             * ENDPOINTS
             */

            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("try [/api]/gettall or " +
                    "[api]/getallauthors \n and so on\n");
                await next();
            });

            app.UseRouting();//just enabling routing, not calling endpoint
                             //a routing is basically mapping the incoming http request method

            // app.Map("", IndexMiddleware);//not routing to next??

            app.UseEndpoints(endpoints =>
            {
                //addcontrollers sevice requires own route mapping. 
                //those below is empty template and self mapping. so, comment them.
                //and add mapcontrollers.

                endpoints.MapControllers();//enables controllers' action methods to route

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

        private void IndexMiddleware(IApplicationBuilder app)
        {
            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("now try endpointsrouting in address bar \n " +
                "add [/api]/gettall or /getallauthors\n");
                await next();
            });
        }

        private void BuiltinMiddleware(IApplicationBuilder app)
        {
            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("response from custom-mapped " +
                    "builtInMiddleware via the route /saga \n");
            });
        }
    }
}
