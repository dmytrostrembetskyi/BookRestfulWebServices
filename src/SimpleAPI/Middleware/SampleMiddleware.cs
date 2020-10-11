using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace SimpleAPI.Middleware
{
    public class SampleMiddleware
    {
        private readonly RequestDelegate _next;

        public SampleMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // my logic
            await context.Response.WriteAsync("Hello from middleware!");

            await _next(context);
        }
    }
}
