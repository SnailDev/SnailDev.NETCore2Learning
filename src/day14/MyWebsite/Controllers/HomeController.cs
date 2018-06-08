using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebsite.Filters;

namespace MyWebsite.Controllers
{
    // [TypeFilter(typeof(AuthorizationFilter))]
    // [AuthorizationFilter]
    // [AsyncAuthorizationFilter]
    [ActionFilter(Name = "Controller", Order = 2)]
    public class HomeController : Controller
    {
        // [TypeFilter(typeof(ActionFilter))]
        // [ActionFilter]
        // [AsyncActionFilter]
        [ActionFilter(Name = "Action", Order = 1)]
        public void Index()
        {
            Response.WriteAsync("Hello World! \r\n");
        }

        // [TypeFilter(typeof(ActionFilter))]
        // [ActionFilter]
        // [AsyncActionFilter]
        public void Error()
        {
            throw new System.Exception("Error");
        }
    }
}