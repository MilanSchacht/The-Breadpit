using System.ComponentModel.DataAnnotations.Schema;

namespace The_Breadpit.Models
{
    public enum Category { Meat, Veggie, WarmMeal, ColdDrink, SoftDrink, WarmDrink }
    public class Product
    {
        public int Id { get; set; }
        public Category Category { get; set; }
        public string ProductName { get; set; }
        [Column(TypeName ="decimal(6, 2)")]
        public double Price { get; set; }
    }
}
