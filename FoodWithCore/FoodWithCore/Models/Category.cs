using System.ComponentModel.DataAnnotations;

namespace FoodWithCore.Models
{
    public class Category
    {
        public int CategoryID { get; set; }

        [Required(ErrorMessage = "Category Name Not Empty")]
        public string CategoryName { get; set; }

        public string CategoryDescription { get; set; }

        public List<Food> Foods { get; set; }
    }
}
