using CoreAndFood.Repository;
using Microsoft.AspNetCore.Mvc;

namespace FoodWithCore.ViewComponents
{
	public class FoodListByCategory:ViewComponent
	{
		public IViewComponentResult Invoke(int id)
		{
			FoodRepository repository = new FoodRepository();
			var foodlist = repository.List(x => x.CategoryID == id);
			return View(foodlist);
		}
	}
}
