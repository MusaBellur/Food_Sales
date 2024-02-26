using FoodWithCore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

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
        public IActionResult Statistics()
        {
            Context c = new Context();

            var deger1 = c.Foods.Count();
            ViewBag.d1 = deger1;

            var deger2 = c.Categories.Count();
            ViewBag.d2 = deger2;

            var fruitId = c.Categories.Where(x => x.CategoryName == "Fruits").Select(y => y.CategoryID).FirstOrDefault();
            var deger3 = c.Foods.Where(x => x.CategoryID == fruitId).Count();
            ViewBag.d3 = deger3;

            var vegetableId = c.Categories.Where(x => x.CategoryName == "Vegetables").Select(y => y.CategoryID).FirstOrDefault();
            var deger4 = c.Foods.Where(x => x.CategoryID == vegetableId).Count();
            ViewBag.d4 = deger4;
            
            var deger5 = c.Foods.Sum(x => x.Stock);
            ViewBag.d5 = deger5;

            var deger6 = c.Foods.Where(x => x.CategoryID == c.Categories.Where(y => y.CategoryName == "Grains").Select(z => z.CategoryID).FirstOrDefault()).Count();
            ViewBag.d6 = deger6;
            
            var deger7 = c.Foods.OrderByDescending(x => x.Stock).Select(y => y.Name).FirstOrDefault();
            ViewBag.d7 = deger7;
            
            var deger8 = c.Foods.OrderBy(x => x.Stock).Select(y => y.Name).FirstOrDefault();
            ViewBag.d8 = deger8;
            
            var deger9 = c.Foods.Average(x => x.Price).ToString("0.00");
            ViewBag.d9 = deger9;

            var deger10 = c.Foods.Where(x => x.CategoryID == fruitId).Sum(y => y.Stock);
            ViewBag.d10 = deger10;
            
            var deger11 = c.Foods.Where(x => x.CategoryID == vegetableId).Sum(y => y.Stock);
            ViewBag.d11 = deger11;

            var deger12 = c.Foods.OrderByDescending(x => x.Price).Select(y => y.Name).FirstOrDefault();
            ViewBag.d12 = deger12;

            return View();
        }
    }
}
