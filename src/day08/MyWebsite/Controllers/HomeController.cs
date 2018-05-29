using Microsoft.AspNetCore.Mvc;
using MyWebsite.Models;

namespace MyWebsite.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var user = new UserModel();
            return View(model: user);
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Share()
        {
            var user = new UserModel();
            return View(model: user);
        }
    }
}