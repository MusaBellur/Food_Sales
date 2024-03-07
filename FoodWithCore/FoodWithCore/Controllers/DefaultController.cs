using Microsoft.AspNetCore.Mvc;

namespace FoodWithCore.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CategoryDetails(int id) 
        {
            ViewBag.y = id;
            return View();
        }
    }
}
