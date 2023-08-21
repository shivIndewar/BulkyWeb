using BulkyWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace BulkyWeb.DataAccess.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        { 

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                    new Category { Id =1, Name="Action", DisplayOrder= 1 },
                    new Category { Id = 2, Name = "SciFi", DisplayOrder = 2 },
                    new Category { Id = 3, Name = "History", DisplayOrder = 3 },
                    new Category { Id = 4, Name = "test1", DisplayOrder = 4 }
                );

            modelBuilder.Entity<Product>().HasData(
                     new Product { Id = 1, Title="CPP", Description="Complete CPP programming", Author="shiv khera", ISBN="shiv khera", ListPrice=100, Price=500, Price50=1000, Price100=1500 },
                     new Product { Id = 2, Title = "JAVA", Description = "Complete JAVA programming", Author = "shiv khera", ISBN = "shiv khera", ListPrice = 200, Price = 600, Price50 = 1100, Price100 = 1700 },
                     new Product { Id = 3, Title = "C#", Description = "Complete C# programming", Author = "shiv khera", ISBN = "shiv khera", ListPrice = 250, Price = 650, Price50 = 1150, Price100 = 1750 },
                     new Product { Id = 4, Title = "DOT NET", Description = "Complete DOT NET programming", Author = "shiv khera", ISBN = "shiv khera", ListPrice = 350, Price = 750, Price50 = 1250, Price100 = 1850 },
                     new Product { Id = 5, Title = "C#", Description = "Complete C# programming", Author = "shiv khera", ISBN = "shiv khera", ListPrice = 350, Price = 750, Price50 = 1250, Price100 = 1950 }
                );
        }
    }
}
