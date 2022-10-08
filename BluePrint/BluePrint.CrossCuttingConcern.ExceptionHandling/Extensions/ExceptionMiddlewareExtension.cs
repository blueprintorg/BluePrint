using BluePrint.CrossCuttingConcern.ExceptionHandling.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace BluePrint.CrossCuttingConcern.ExceptionHandling.Extensions
{
    public static class ExceptionMiddlewareExtension
    {
        public static void ConfigureCustomExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
