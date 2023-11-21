using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Threading.Tasks;

namespace MiddeleWares.MiddleWares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class RequestEditMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestEditMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            string temp = httpContext.Request.Headers["User-Agent"]; 
            httpContext.Items["IsChromeBrowser"] = httpContext.Request.Headers["User-Agent"].Any(p => p.ToLower().Contains("chrome"));
            await _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class RequestEditMiddlewareExtensions
    {
        public static IApplicationBuilder UseRequestEditMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestEditMiddleware>();
        }
    }
}
