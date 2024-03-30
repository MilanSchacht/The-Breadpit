using The_Breadpit.Models;
using Microsoft.EntityFrameworkCore;

namespace The_Breadpit.Data
{
    public class BreadPitContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<OrderDetail> OrderDetails { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=The_Breadpit-Orders;Integrated Security=True;");
        }
    }
}
