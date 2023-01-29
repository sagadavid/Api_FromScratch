using FromScratchConsole2WebApi.Controllers;
using FromScratchConsole2WebApi.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
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
            services.AddTransient<CustomFileMiddleware>();//custom middleware class requires dependency injection.
        
            //to use singleton, present the interface to the class that will be implemented of
            services.AddSingleton<IProductRepository, ProductRepository> ();

            //scoped.. the instance of interface lifetime will be inthe scope of httprequest
            //which means eath httppost will create a new repository instanse and old posted data will be gone
            //services.AddScoped<IProductRepository, ProductRepository>();

            //transient ... each request create new instance .. when used, in our example.. we use 2 instances of same interfaces
            //one instance adds sends data (new product), other instance holds data (list, products)
            //in singleton, it would summoned together and we would see all products, 
            //when it is transient, two instances' calls/request will cause to create a new service and two sendings will never meet/summon
            //as a result a product should be sent, but when all products called a totally new service will 
            //be created and we wont see any data, its empty because it is totally new 
            //services.AddTransient<IProductRepository, ProductRepository>();

            //a second repo is using same interface.. then old service is lost
            //which means old features of app is lost.. 
            //here below we implement secondrepo and get name from seconrepo..
            //if we change order, put this line behind addtransient line, then we get name from productrepo this time
            //to prevent this try versions are used. tryscoped, trytransient, trysingleton
            //if try used, means, the first service is valid if tried earlier.. second skipps
            //so...
            //services.TryAddTransient<IProductRepository, ProductRepository>();
            //services.TryAddTransient<IProductRepository, SecondRepos4SameInterface>();





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
            
            app.UseMiddleware<CustomFileMiddleware>();

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

            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync("try [/api]/gettall or " +
            //        "[api]/getallauthors \n and so on\n");
            //    await next();
            //});

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
