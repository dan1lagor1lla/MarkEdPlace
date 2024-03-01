using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;
using static System.Net.WebRequestMethods;

namespace MarkEdPlace.model
{
    internal class MarkEdPlaceContext : DbContext
    {
        public DbSet<User> Users => Set<User>();
        public DbSet<Product> Products => Set<Product>();
        public DbSet<Vendor> Vendors => Set<Vendor>();
        public DbSet<Purchase> Purchases => Set<Purchase>();
        public DbSet<Cart> Cart => Set<Cart>();

        public MarkEdPlaceContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            ConfigurationBuilder configBuilder = new();
            configBuilder.SetBasePath(Directory.GetCurrentDirectory());
            configBuilder.AddJsonFile("config.json");

            var config = configBuilder.Build();
            optionsBuilder.UseSqlite(config.GetConnectionString("DefaultString"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User").HasData([new User("user", "user@mail.ru", "123") { ID = 1 }]);
            List<Vendor> vendors = [new Vendor("Искатель") { ID = 1 }, new Vendor("Экзамен") { ID = 2 }];
            modelBuilder.Entity<Vendor>().ToTable("Vendor").HasData([new Vendor("Искатель") { ID = 1 }, new Vendor("Экзамен") { ID = 2 }]);

            List<Product> x = [
                new Product("Корягин, Корягина: Python. Великое программирование в Minecraft", 292, 31) { ID = 1, ImagePath = "productImages\\mine.png", VendorID = 1 },
                new Product("Бучик, Бучик: Словарь в картинках. Добро пожаловать в Кукуево", 355, 12) { ID = 2, ImagePath = "productImages\\dic.png", VendorID = 1 },
                new Product("Мельникова, Мельников: ВПР. История. 6 класс. Типовые задания. 25 вариантов. ФГОС", 1525, 212) { ID = 3, ImagePath = "productImages\\his.png", VendorID = 1 },
                new Product("Математика. Таблица умножения. 2-3 классы. Тренажер. ФГОС.", 235, 43) { ID = 5, ImagePath = "productImages\\cover.png", VendorID = 1 },
                new Product("Мамин-Сибиряк, Крылов, Ушинский: Внеклассное чтение. 1-4 классы. Родная речь", 235, 0) { ID = 6, ImagePath = "productImages\\read.png", VendorID = 1 }];
            modelBuilder.Entity<Product>().ToTable("Product").HasData(x);
            modelBuilder.Entity<Purchase>().ToTable("Purchase");

            

            modelBuilder.Entity<User>().HasMany(user => user.ProductsInCart).WithMany().UsingEntity<Cart>();
        }
    }
}
