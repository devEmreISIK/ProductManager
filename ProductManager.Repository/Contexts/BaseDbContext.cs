using Microsoft.EntityFrameworkCore;
using ProductManager.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManager.Repository.Contexts;

public class BaseDbContext : DbContext
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Data Source=EMRE;Initial Catalog=ProductManager;Integrated Security=True;TrustServerCertificate=true;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>().HasData(
            new Category { Id = 1, CategoryName = "Electronics"},
            new Category { Id = 2, CategoryName = "Fashion" }
            );

        modelBuilder.Entity<Product>().HasData(
            new Product { Id = 1, ProductName = "HP Laptop", Stock=25, Price=42599, CategoryId=1},
            new Product { Id = 2, ProductName = "Asus Laptop", Stock = 255, Price = 40599, CategoryId = 1 },
            new Product { Id = 3, ProductName = "Nike Running Shoe", Stock = 788, Price = 4990, CategoryId = 2 }
            );
    }
}
