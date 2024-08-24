using Microsoft.EntityFrameworkCore;
using Bangazon_BE.Models;
using Bangazon_BE.DTOs;
using Bangazon_BE.Data;

public class Bangazon_BEDbContext : DbContext
{
    public DbSet<Categories> Categories { get; set; }
    public DbSet<Orders> Orders { get; set; }
    public DbSet<PaymentTypes> PaymentTypes { get; set; }
    public DbSet<Products> Products { get; set; }
    public DbSet<Users> Users { get; set; }

    public Bangazon_BEDbContext(DbContextOptions<Bangazon_BEDbContext> context) : base(context)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Send data to Categories
        modelBuilder.Entity<Categories>().HasData(CategoriesData.Categories);

        // Send data to Orders
        modelBuilder.Entity<Orders>().HasData(OrdersData.Orders);

        // Send data to PaymentTypes
        modelBuilder.Entity<PaymentTypes>().HasData(PaymenTypesData.PaymentTypes);

        // Send data to Products
        modelBuilder.Entity<Products>().HasData(ProductData.Products);

        // Send data to Users
        modelBuilder.Entity<Users>().HasData(UserData.Users);
    }
}