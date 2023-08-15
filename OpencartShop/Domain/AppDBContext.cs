using Microsoft.EntityFrameworkCore;
using OpencartShop.Domain.Entities;

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
        public AppDBContext()
        {
            Database.EnsureCreatedAsync();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite("Data Source=db.db");
        }

    }
}
