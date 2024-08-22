using Api.Storage.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Api.Storage;

public class AppDbContext(DbContextOptions<AppDbContext> options) : IdentityDbContext<User, Role, int,
IdentityUserClaim<int>, UserRole, IdentityUserLogin<int>,
IdentityRoleClaim<int>, IdentityUserToken<int>>(options)
{
    public DbSet<Category> Categories { get; set; } = null!;
    public DbSet<Product> Products { get; set; } = null!;
    public DbSet<DeliveryMethod> DeliveryMethods { get; set; } = null!;
    public DbSet<PaymentMethod> PaymentMethods { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Address> Addresses { get; set; } = null!;
    public DbSet<FavoriteProduct> LikeProducts { get; set; } = null!;
    public DbSet<CartItem> CartItems { get; set; } = null!;
    public DbSet<Order> Orders { get; set; } = null!;
    public DbSet<OrderItem> OrderItems { get; set; } = null!;
    public DbSet<ReturnProduct> ReturnProducts { get; set; } = null!;
    public DbSet<CustomerReview> CustomerReviews { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        const string STAR_COUNT = nameof(Entities.CustomerReview.StarCount);
        builder.Entity<CustomerReview>()
                    .ToTable(c => c.HasCheckConstraint(STAR_COUNT, $"{STAR_COUNT} > 0 AND {STAR_COUNT} <= 5"));
        //modelBuilder.Entity<Users>().Property(u => u.IsAdmin).HasDefaultValue(false);
        builder.Entity<FavoriteProduct>().HasKey(fp => new { fp.ProductId, fp.UserId });
        builder.Entity<Role>().HasData(new Role
        {
            Id = 1,
            Name = Entities.Roles.ADMIN,
            NormalizedName = nameof(Entities.Roles.ADMIN).ToUpper()
        });

        builder.Entity<Role>().HasData(new Role
        {
            Id = 2,
            Name = Entities.Roles.CUSTOMER,
            NormalizedName = nameof(Entities.Roles.CUSTOMER).ToUpper()
        });

        //modelBuilder.Entity<Customer>().HasData(new Customer
        //{
        //    Id = 1,
        //    FirstName = "Admin",
        //    LastName = "Admin",
        //    Phone = "+38(...)...-..-..",
        //    Email = "mail@gmail.com"
        //});
        //modelBuilder.Entity<User>().HasData(new User
        //{
        //    Id = 1,
        //    CustomersId = 1,
        //    IsAdmin = true,
        //    PasswordHash = AuthConfigs.GetAdminPasswordHash()
        //});

        var category = new Category
        {
            Id = 1,
            Title = "Popular",
        };

        builder.Entity<Category>().HasData(category);
    }
}
