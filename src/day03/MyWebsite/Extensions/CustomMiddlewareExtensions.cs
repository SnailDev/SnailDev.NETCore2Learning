using Microsoft.AspNetCore.Builder;

namespace MyWebsite
{
    public static class CustomMiddlewareExtensions
    {
        public static IApplicationBuilder UseFirstMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<FirstMiddleware>();
        }
    }
}