using CoreAndFood.Repository;
using Microsoft.AspNetCore.Mvc;

namespace FoodWithCore.ViewComponents
{
    public class CategoryGetList:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            CategoryRepository repository = new CategoryRepository();
            var categorylist = repository.TList();
            return View(categorylist);
        }
    }
}
