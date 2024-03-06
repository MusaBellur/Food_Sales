using CoreAndFood.Repository;
using Microsoft.AspNetCore.Mvc;

namespace FoodWithCore.ViewComponents
{
	public class FoodGetList:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			FoodRepository repository = new FoodRepository();
			var foodlist = repository.TList();
			return View(foodlist);
		}
	}
}
