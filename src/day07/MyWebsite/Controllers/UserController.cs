using Microsoft.AspNetCore.Mvc;
using MyWebsite.Models;

namespace MyWebsite.Controllers
{
    // [Route("[controller]")]
    public class UserController : Controller
    {
        //   [Route("")]
        public IActionResult Profile()
        {
            var user = new UserModel();
            return View(model: user);
        }

        [Route("change-password")]
        public IActionResult ChangePassword()
        {
            return View();
        }

        // [Route("[action]")]
        public IActionResult Other()
        {
            return View();
        }
    }
}