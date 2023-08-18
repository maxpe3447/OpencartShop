using Microsoft.EntityFrameworkCore;
using OpencartShop.Domain.Entities;
using System;

namespace OpencartShop.Domain
{
    public class AppDBContext : DbContext
    {
        public DbSet<Colors> Colors { get; set; } = null!;
        public DbSet<Catalog> Catalog { get; set; } = null!;
        public DbSet<SubCatalog> SubCatalog { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Products> Products { get; set; } = null!;
        public DbSet<ProductColors> ProductColors { get; set; } = null!;
        public DbSet<ProductSizes> ProductSizes { get; set; } = null!;
        public DbSet<DeliveryMethods> DeliveryMethods { get; set; } = null!;
        public DbSet<PaymentMethod> PaymentMethods { get; set; } = null!;
        public DbSet<Customers> Customers { get; set; } = null!;
        public DbSet<Users> Users { get; set; } = null!;
        public DbSet<Addresses> Addresses { get; set; } = null!;
        public DbSet<FavoriteProducts> LikeProducts { get; set; } = null!;
        public DbSet<Carts> Carts { get; set; } = null!;
        public DbSet<CartItem> CartItems { get; set; } = null!;
        public DbSet<Orders> Orders { get; set; } = null!;
        public DbSet<OrderItems> OrderItems { get; set; } = null!;
        public DbSet<ReturnProducts> ReturnProducts{ get; set; } = null!;
        public DbSet<CustomerReviews> CustomerReviews{ get; set; } = null!;
        
        public AppDBContext(DbContextOptions<AppDBContext> options)
            : base(options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreatedAsync();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            const string STAR_COUNT = nameof(Entities.CustomerReviews.StarCount);
            modelBuilder.Entity<CustomerReviews>()
                        .ToTable(c=>c.HasCheckConstraint(STAR_COUNT, $"{STAR_COUNT} > 0 AND {STAR_COUNT} <= 5"));
            //modelBuilder.Entity<Users>().Property(u => u.IsAdmin).HasDefaultValue(false);
        }
    }
}
