using Microsoft.AspNetCore.Mvc;

namespace FoodWithCore.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
