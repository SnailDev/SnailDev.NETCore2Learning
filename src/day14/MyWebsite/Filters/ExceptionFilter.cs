using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MyWebsite.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            context.ExceptionHandled = true;
            context.HttpContext.Response.WriteAsync($"{GetType().Name} in. \r\n");
        }
    }

    public class AsyncExceptionFilter : IAsyncExceptionFilter
    {
        public Task OnExceptionAsync(ExceptionContext context)
        {
            context.ExceptionHandled = true;
            context.HttpContext.Response.WriteAsync($"{GetType().Name} in. \r\n");
            return Task.CompletedTask;
        }
    }
}