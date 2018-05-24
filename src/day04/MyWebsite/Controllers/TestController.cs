using Microsoft.AspNetCore.Mvc;
using MyWebsite.Models;

namespace MyWebsite.Controllers
{
    public class TestController : Controller
    {
        private readonly ISample _transient;
        private readonly ISample _scoped;
        private readonly ISample _singleton;

        public TestController(
            ISampleTransient transient,
            ISampleScoped scoped,
            ISampleSingleton singleton)
        {
            _transient = transient;
            _scoped = scoped;
            _singleton = singleton;
        }

        public IActionResult Index()
        {
            ViewBag.TransientId = _transient.Id;
            ViewBag.TransientHashCode = _transient.GetHashCode();

            ViewBag.ScopedId = _scoped.Id;
            ViewBag.ScopedHashCode = _scoped.GetHashCode();

            ViewBag.SingletonId = _singleton.Id;
            ViewBag.SingletonHashCode = _singleton.GetHashCode();
            return View();
        }
    }
}