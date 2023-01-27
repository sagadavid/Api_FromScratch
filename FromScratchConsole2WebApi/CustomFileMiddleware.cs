using Microsoft.AspNetCore.Http;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FromScratchConsole2WebApi
{
    public class CustomFileMiddleware : IMiddleware //inherit and implement interface
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
           await context.Response.WriteAsync($"response from {nameof(CustomFileMiddleware)} invokemethod 1 \n");
            await next(context );//when it is custom/seperate class/file, need to pass context in the next method
            await context.Response.WriteAsync($"response from {nameof(CustomFileMiddleware)} invokemethod 2 \n");
        }
    }
}
