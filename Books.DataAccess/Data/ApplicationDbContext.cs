using Books.Models;
using Microsoft.EntityFrameworkCore;

namespace Books.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Product { get; set; }
        //public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<Company> Company { get; set; }
        //public DbSet<ShoppingCart> ShoppingCart { get; set; }
        //public DbSet<OrderHeader> OrderHeader { get; set; }
        //public DbSet<OrderDetail> OrderDetail { get; set; }
        //public DbSet<ProductImage> ProductImage { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed data category
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "William", DisplayOrder = 1 },
                new Category { Id = 2, Name = "Scifi", DisplayOrder = 2 },
                new Category { Id = 3, Name = "History", DisplayOrder = 3 }
             );

            // Seed data product
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Title = "Fortune of Time",
                    Description = "Praesent vite sodales libero",
                    ISBN = "SWD999999901",
                    ListPrice = 99,
                    Price = 90,
                    Price50 = 85,
                    Price100 = 80,
                    Author = "Billy Spack",
                    CategoryId = 1,
                }
            );

            // Seed data company
            modelBuilder.Entity<Company>().HasData(
                new Company
                {
                    Id = 1,
                    Name = "Lomus",
                    City = "Chicago",
                    PhoneNumber = "+840973434504",
                    PostalCode = "5684789699",
                    State = "IL",
                    StreetAddress = "999 Vid St"
                }
             );
        }
    }
}
