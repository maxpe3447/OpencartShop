using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OpencartShop.Domain.Entities;
using OpencartShop.Helpers;
using System;

namespace OpencartShop.Domain
{
    public class AppDBContext : DbContext
    {
        public DbSet<Color> Colors { get; set; } = null!;
        public DbSet<Catalog> Catalog { get; set; } = null!;
        public DbSet<SubCatalog> SubCatalog { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<ProductColor> ProductColors { get; set; } = null!;
        public DbSet<ProductSize> ProductSizes { get; set; } = null!;
        public DbSet<DeliveryMethod> DeliveryMethods { get; set; } = null!;
        public DbSet<PaymentMethod> PaymentMethods { get; set; } = null!;
        public DbSet<Customer> Customers { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Address> Addresses { get; set; } = null!;
        public DbSet<FavoriteProduct> FavoriteProducts { get; set; } = null!;
        public DbSet<Cart> Carts { get; set; } = null!;
        public DbSet<CartItem> CartItems { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<OrderItem> OrderItems { get; set; } = null!;
        public DbSet<ReturnProduct> ReturnProducts{ get; set; } = null!;
        public DbSet<CustomerReview> CustomerReviews{ get; set; } = null!;
        
        public AppDBContext(DbContextOptions<AppDBContext> options)
            : base(options)
        {
            //Database.EnsureDeletedAsync();
            Database.EnsureCreatedAsync();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            const string STAR_COUNT = nameof(Entities.CustomerReview.StarCount);
            modelBuilder.Entity<CustomerReview>()
                        .ToTable(c=>c.HasCheckConstraint(STAR_COUNT, $"{STAR_COUNT} > 0 AND {STAR_COUNT} <= 5"));
            //modelBuilder.Entity<Users>().Property(u => u.IsAdmin).HasDefaultValue(false);


            modelBuilder.Entity<Customer>().HasData(new Customer
            {
                Id = 1,
                FirstName = "Admin",
                LastName = "Admin",
                Phone = "+38(...)...-..-..",
                Email = "mail@gmail.com"
            });
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 1,
                CustomersId = 1,
                IsAdmin = true,
                PasswordHash = AuthConfigs.GetAdminPasswordHash()
            });

            modelBuilder.Entity<Catalog>().HasData(new Catalog
            {
                Id = 1,
                Title = "Test"
            });
            modelBuilder.Entity<SubCatalog>().HasData(new SubCatalog
            {
                Id = 1,
                Title = "Test",
                ParentCatalog = 1
            }) ;
            modelBuilder.Entity<Category>().HasData(new Category
            {
                Id = 1,
                Title = "Test",
                SubcategoryId = 1
            });

        }
    }
}
