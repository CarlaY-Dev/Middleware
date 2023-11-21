using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace MiddeleWares.MiddleWares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ContentMiddleware
    {
        private readonly RequestDelegate _next;

        public ContentMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            await _next(httpContext);
            if (httpContext.Request.Path.ToString().ToLower().Contains("/content"))
            {
                await httpContext.Response.WriteAsync("This message from content...!");
            }
           
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ContentMiddlewareExtensions
    {
        public static IApplicationBuilder UseContentMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ContentMiddleware>();
        }
    }
}
