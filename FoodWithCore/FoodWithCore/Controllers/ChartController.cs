using FoodWithCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace FoodWithCore.Controllers
{
    public class ChartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Index2() 
        {
            return View(); 
        }
        public IActionResult VisualizeProductResult()
        {
            return Json(ProList());
        }
        public List<Class> ProList()
        {
            List<Class> list = new List<Class>();
            list.Add(new Class
            {
                proname = "Computer",
                stock = 150
            });
            list.Add(new Class
            {
                proname = "Phone",
                stock = 75
            });
            list.Add(new Class
            {
                proname = "TV",
                stock = 300
            });
            return list;
        }
        public IActionResult Index3()
        {
            return View();
        }
        public IActionResult VisualizeProductResult2()
        {
            return Json(FoodList());
        }
        public List<Class1> FoodList()
        {
            List<Class1> list2 = new List<Class1>();
            using(var c =new Context())
            {
                list2 = c.Foods.Select(f => new Class1
                {
                    foodname = f.Name,
                    stock = f.Stock
                }).ToList();
            }
            return list2;
        }
    }
}
