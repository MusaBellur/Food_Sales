using CoreAndFood.Repository;
using Microsoft.AspNetCore.Mvc;

namespace FoodWithCore.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            CategoryRepository categoryRepository = new CategoryRepository();
            return View(categoryRepository.TList());
        }
    }
}
