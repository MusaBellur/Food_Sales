using CoreAndFood.Repository;
using Microsoft.AspNetCore.Mvc;

namespace FoodWithCore.Controllers
{
    public class FoodController : Controller
    {
        public IActionResult Index()
        {
            FoodRepository foodRepository = new FoodRepository();
            return View(foodRepository.TList("Category"));
        }
    }
}
