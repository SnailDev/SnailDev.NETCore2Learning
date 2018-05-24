using Microsoft.AspNetCore.Mvc;
using MyWebsite.Models;

namespace MyWebsite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISample _sample;

        public HomeController(ISample sample)
        {
            _sample = sample;
        }

        public string Index()
        {
            return $"[ISample]\r\n"
                 + $"Id: {_sample.Id}\r\n"
                 + $"HashCode: {_sample.GetHashCode()}\r\n"
                 + $"Tpye: {_sample.GetType()}";
        }
    }
}