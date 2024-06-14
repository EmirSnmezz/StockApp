using Microsoft.EntityFrameworkCore;
using StockApp.Models.Entites.Concrete;

namespace StockApp.Models
{
    public class MyDbContext :DbContext
    {
       public MyDbContext(DbContextOptions options) : base(options) 
        {
        }

       public DbSet<Product> Products { get; set;}
        public DbSet<Order> Orders { get; set;}
        public DbSet<Customer> Customers { get; set;}
        public DbSet<Category> Categories { get; set;}
        public DbSet<Brand> Brands  { get; set; }
    }
}
