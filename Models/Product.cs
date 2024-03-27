namespace The_Breadpit.Models
{
    public enum Category { Meat, Veggie, WarmMeal, ColdDrink, SoftDrink, WarmDrink }
    public class Product
    {
        public int Id { get; set; }
        public Category Category { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        
        public void AddProduct(Category c, string pn, int pr)
        {
            Id++;
            Category = c;
            ProductName = pn;
            Price = pr;
        }

        public void AddProductToDatabase(Product p)
        {
            Console.WriteLine(p);
            
            // Future DB code
        }
    }
}
