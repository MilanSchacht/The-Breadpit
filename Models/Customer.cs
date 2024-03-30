namespace The_Breadpit.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public Account Account { get; set; }
        public ICollection<Order> Orders { get; set; } = null!;
    }
}
