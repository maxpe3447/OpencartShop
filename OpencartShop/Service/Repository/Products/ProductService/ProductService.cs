using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using OpencartShop.Domain;
using OpencartShop.Domain.Entities;

namespace OpencartShop.Service.Repository.Products.ProductService
{
    public class ProductService : IProductService
    {
        private readonly AppDBContext _appDBContext;
        public ProductService(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }
        public void AddProduct(Product product) => Save(product);

        public void DeleteProductById(int id)
        {
            _appDBContext.Products.Remove(new Product { Id = id });
            _appDBContext.SaveChanges();
        }

        public void EditProduct(Product size) => Save(size);

        public IQueryable<Product> GetAllProducts()
        {
            return _appDBContext.Products.Include(p => p.ProductColors)
                                            .ThenInclude(c => c.Color)
                                         .Include(p=>p.ProductSizes)
                                         .Include(p=>p.CustomerReviews);
        }

        public IQueryable<Product> GetAllProductsByCategoryId(int id)
        {
            return _appDBContext.Products.Where(p => p.CategoryId == id)
                                         .Include(p => p.ProductColors)
                                            .ThenInclude(c => c.Color)
                                         .Include(p => p.ProductSizes)
                                         .Include(p => p.CustomerReviews);
        }

        public Product? GetProductById(int id)
        {
            var product = _appDBContext.Products.FirstOrDefault(p => p.Id == id);
            if(product == default)
            {
                return new Product();
            }

            _appDBContext.Entry(product).Collection(p=>p.ProductSizes).Load();
            _appDBContext.Entry(product).Collection(p=>p.ProductColors).Load();

            return product;
        }

        private void Save(Product product)
        {
            if(product.Id == default)
            {
                _appDBContext.Entry(product).State = EntityState.Added;
            }
            else
            {
                _appDBContext.Entry(product).State = EntityState.Modified;
            }
            _appDBContext.SaveChanges();
        }
    }
}
