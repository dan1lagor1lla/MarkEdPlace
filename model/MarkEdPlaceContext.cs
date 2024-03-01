using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

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

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            ConfigurationBuilder configBuilder = new();
            configBuilder.SetBasePath(Directory.GetCurrentDirectory());
            configBuilder.AddJsonFile("config.json");

            var config = configBuilder.Build();
            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultString"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Vendor>().ToTable("Vendor");
            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<Purchase>().ToTable("Purchase");

            modelBuilder.Entity<User>().HasMany(user => user.ProductsInCart).WithMany().UsingEntity<Cart>();
        }
    }
}
