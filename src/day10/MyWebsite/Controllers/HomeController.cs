using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MyWebsite.Models;

namespace MyWebsite.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            // var user = new UserModel();
            // return View(model: user);

            return View(new List<UserModel>()
            {
                new UserModel()
                {
                    Id = 1,
                    Name = "John",
                    Email = "john@xxx.xxx",
                },
                new UserModel()
                {
                    Id = 2,
                    Name = "Blackie",
                    Email = "blackie@xxx.xxx"
                },
                new UserModel()
                {
                    Id = 3,
                    Name = "Claire",
                    Email = "claire@xxx.xxx"
                }
            });
        }

        public IActionResult Share()
        {
            var user = new UserModel();
            return View(model: user);
        }

        public IActionResult Razor()
        {
            return View();
        }

        public IActionResult Sample()
        {
            return View();
        }
    }
}