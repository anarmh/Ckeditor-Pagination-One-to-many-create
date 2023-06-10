using Fiorello_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Fiorello_backend.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> option) : base(option)
        {
        }

        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<SliderInfo> SliderInfos { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Expert> Experts { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Setting> Settings { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasQueryFilter(m => !m.SoftDelete);
            modelBuilder.Entity<Slider>().HasQueryFilter(m => !m.SoftDelete);
            modelBuilder.Entity<Category>().HasQueryFilter(m => !m.SoftDelete);

            modelBuilder.Entity<Customer>().HasData(
            new Customer
            {
                Id = 1,
                FullName = "Rasul Hasanov",
                Age = 16,
            },
            new Customer
            {
                Id = 2,
                FullName = "Novreste Aslanzade",
                Age = 25,
            },
            new Customer
            {
                Id = 3,
                FullName = "Musa Afandiyev",
                Age = 19,
            });



            modelBuilder.Entity<Setting>().HasData(
            new Setting
            {
                Id = 1,
                Key = "HeaderLogo",
                Value = "logo.png",
            },
            new Setting
            {
                Id = 2,
                Key = "Phone",
                Value = "7456834857634",
            },
            new Setting
            {
                Id = 3,
                Key = "Email",
                Value = "fiorello@gmail.com",
            });

        }
    }
}
