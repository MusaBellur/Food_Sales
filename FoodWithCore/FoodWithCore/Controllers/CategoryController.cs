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
            if (ModelState.IsValid)
            {
                categoryRepository.TAdd(p);
                return RedirectToAction("Index");
            }
            return View("AddCategory");
        }
        public IActionResult GetCategory(int id)
        {
            var x = categoryRepository.TFind(id);
            Category ct = new Category()
            {
                CategoryID = x.CategoryID,
                CategoryName = x.CategoryName,
                CategoryDescription = x.CategoryDescription
            };
            return View(ct);
        }
        [HttpPost]
        public IActionResult UpdateCategory(Category p)
        {
            var x = categoryRepository.TFind(p.CategoryID);
            x.CategoryName = p.CategoryName;
            x.CategoryDescription = p.CategoryDescription;
            x.Status = true;
            categoryRepository.TUpdate(x);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteCategory(int id) 
        {
            var x = categoryRepository.TFind(id);
            x.Status = false;
            categoryRepository.TUpdate(x);
            return RedirectToAction("Index");
        }
    }
}
