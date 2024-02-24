using CoreAndFood.Repository;
using FoodWithCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using X.PagedList;

namespace FoodWithCore.Controllers
{
    public class FoodController : Controller
    {
        Context c = new Context();
        FoodRepository foodRepository = new FoodRepository();

        public IActionResult Index(int page = 1)
        {
            return View(foodRepository.TList("Category").ToPagedList(page, 3));
        }

        [HttpGet]
        public IActionResult AddFood()
        {
            List<SelectListItem> values = (from x in c.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryID.ToString()
                                           }).ToList();
            ViewBag.v1 = values;
            return View();
        }

        [HttpPost]
        public IActionResult AddFood(Food p)
        {
            foodRepository.TAdd(p);
            return RedirectToAction("Index");
        }

        public IActionResult GetFood(int id)
        {
            List<SelectListItem> values = (from y in c.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = y.CategoryName,
                                               Value = y.CategoryID.ToString()
                                           }).ToList();
            ViewBag.v1 = values;
            var x = foodRepository.TFind(id);
            Food f = new Food()
            {
                FoodID = x.FoodID,
                Name = x.Name,
                Stock = x.Stock,
                Price = x.Price,
                ImageURL = x.ImageURL,
                CategoryID = x.CategoryID,
                Description = x.Description,
            };
            return View(f);
        }

        [HttpPost]
        public IActionResult UpdateFood(Food p)
        {
            var x = foodRepository.TFind(p.FoodID);
            x.Name = p.Name;
            x.Stock = p.Stock;
            x.Price = p.Price;
            x.ImageURL = p.ImageURL;
            x.CategoryID = p.CategoryID;
            x.Description = p.Description;
            foodRepository.TUpdate(x);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteFood(int id)
        {
            foodRepository.TRemove(new Food { FoodID = id});
            return RedirectToAction("Index");
        }
    }
}
