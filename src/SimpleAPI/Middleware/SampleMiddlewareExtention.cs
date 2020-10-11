using System;
using Microsoft.AspNetCore.Builder;

namespace SimpleAPI.Middleware
{
    public static class SampleMiddlewareExtention
    {
        public static IApplicationBuilder UseSampleMiddleware(this IApplicationBuilder builder)
        {
            // return builder.UseMiddleware<SampleMiddleware>();
            // return builder.Map("/test/path", _ => _.UseMiddleware<SampleMiddleware>());
            return builder.MapWhen(context => context.Request.IsHttps, _ => _.UseMiddleware<SampleMiddleware>());
        }
    }
}
