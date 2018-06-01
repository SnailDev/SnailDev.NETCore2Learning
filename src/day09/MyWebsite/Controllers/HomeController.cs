using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyWebsite.Models;

namespace MyWebsite.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(int id)
        {
            return Content($"id: {id}");
        }

        public IActionResult FirstSample(
            [FromHeader]string header,
            [FromForm]string form,
            [FromRoute]string id,
            [FromQuery]string query)
        {
            return Content($"header: {header}, form: {form}, id: {id}, query: {query}");
        }

        public IActionResult DISample([FromServices] ILogger<HomeController> logger)
        {
            return Content($"logger is null: {logger == null}.");
        }

       public IActionResult BodySample([FromBody]UserModel model)
        {
            // 由于 Id 是 int 类型，int 默认为 0
            // 虽然带上了 [Required]，但不是 null 所以算是有值。
            if (model.Id < 1)
            {
                ModelState.AddModelError("Id", "Id not exist");
            }
            if (ModelState.IsValid)
            {
                return Ok(model);
            }
            
            return BadRequest(ModelState);
        }
    }
}