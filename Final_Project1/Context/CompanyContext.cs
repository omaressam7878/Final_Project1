using Final_Project1.Models;
using Microsoft.EntityFrameworkCore;

namespace Final_Project1.Context
{
    public class CompanyContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-GPUFMS0;DataBase=Final_Project;Trusted_Connection=true;Encrypt=false;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var _Users = new List<User>
            {
                new User { UserId = 1, FirstName = "Omar", LastName = "Essam", Email = "omar.essam@example.com", Password = "Password123!" },
                new User { UserId = 2, FirstName = "Essam", LastName = "Hany", Email = "essam.hany@example.com", Password = "Password123!" },
                new User { UserId = 3, FirstName = "Mohammed", LastName = "Ali", Email = "mohammed.ali@example.com", Password = "Password123!" },
                new User { UserId = 4, FirstName = "Ali", LastName = "Medo", Email = "ali.medo@example.com", Password = "Password123!" },
                new User { UserId = 5, FirstName = "Amr", LastName = "Assem", Email = "amr.assem@example.com", Password = "Password123!" }
            };

            var _Categories = new List<Category>
            {
                new Category { CategoryId = 1, Name = "Gas Turbines", Description = "Products related to gas turbine technology." },
                new Category { CategoryId = 2, Name = "Steam Turbines", Description = "Products related to steam turbine technology." },
                new Category { CategoryId = 3, Name = "Wind Turbines", Description = "Products related to wind turbine technology." },
                new Category { CategoryId = 4, Name = "Power Plant Automation", Description = "Solutions for automating power plants." },
                new Category { CategoryId = 5, Name = "Grid Solutions", Description = "Innovative solutions for smart grids." }
            };

            var _Products = new List<Product>
            {
                new Product { ProductId = 1, Title = "Gas Turbine", CategoryId = 1, Price = 1234567.89m, Description = "High-efficiency gas turbine for power generation.", ImagePath = "https://www.siemens-energy.com/global/en/products/gas-turbines/images/gas_turbine.jpg" },
                new Product { ProductId = 2, Title = "Steam Turbine", CategoryId = 2, Price = 2345678.50m, Description = "Advanced steam turbine designed for maximum performance.", ImagePath = "https://www.siemens-energy.com/global/en/products/steam-turbines/images/steam_turbine.jpg" },
                new Product { ProductId = 3, Title = "Wind Turbine", CategoryId = 3, Price = 3456789.75m, Description = "Innovative wind turbine for sustainable energy production.", ImagePath = "https://www.siemens-energy.com/global/en/products/wind-turbines/images/wind_turbine.jpg" },
                new Product { ProductId = 4, Title = "Power Plant Automation System", CategoryId = 4, Price = 4567890.00m, Description = "Comprehensive automation system for power plants.", ImagePath = "https://www.siemens-energy.com/global/en/products/automation/images/automation_system.jpg" },
                new Product { ProductId = 5, Title = "Grid Solutions", CategoryId = 5, Price = 5678901.25m, Description = "Smart grid solutions for efficient energy management.", ImagePath = "https://www.siemens-energy.com/global/en/products/grid-solutions/images/grid_solutions.jpg" }
            };

            modelBuilder.Entity<User>().HasData(_Users);
            modelBuilder.Entity<Category>().HasData(_Categories);
            modelBuilder.Entity<Product>().HasData(_Products);
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
    }
}
