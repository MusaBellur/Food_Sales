using CoreAndFood.Repository;
using FoodWithCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace FoodWithCore.Controllers
{
    public class CategoryController : Controller
    {
        CategoryRepository categoryRepository = new CategoryRepository();

        public IActionResult Index()
        {
            return View(categoryRepository.TList());
        }
        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddCategory(Category p)
        {
            if (!ModelState.IsValid)
            {
                return View("AddCategory");
            }
            categoryRepository.TAdd(p);
            return RedirectToAction("Index");
        }
    }
}
