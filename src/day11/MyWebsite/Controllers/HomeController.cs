using Microsoft.AspNetCore.Mvc;
using MyWebsite.Wappers;

namespace MyWebsite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISessionWapper _sessionWapper;

        public HomeController(ISessionWapper sessionWapper)
        {
            _sessionWapper = sessionWapper;
        }

        public IActionResult Index()
        {
            var user = _sessionWapper.User;
            if (user == null) user = new Models.UserModel();
            _sessionWapper.User = user;
            return Ok(user);
        }
    }
}