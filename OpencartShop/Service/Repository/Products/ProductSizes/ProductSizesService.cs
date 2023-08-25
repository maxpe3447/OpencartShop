using Microsoft.EntityFrameworkCore;
using OpencartShop.Domain;
using OpencartShop.Domain.Entities;

namespace OpencartShop.Service.Repository.Products.ProductSizes
{
    public class ProductSizesService : IProductSizesService
    {
        private readonly AppDBContext _appContext;
        public ProductSizesService(AppDBContext appDBContext)
        {
            _appContext = appDBContext;
        }
        public void AddSize(ProductSize size) => Save(size);

        public void DeleteSizeById(int id)
            => _appContext.ProductSizes.Remove(new ProductSize { Id = id });

        public void EditSize(ProductSize size) => Save(size);

        public IQueryable<ProductSize> GetAllSizes() => _appContext.ProductSizes;

        public ProductSize? GetSizeById(int id)
            => _appContext.ProductSizes.FirstOrDefault(p => p.Id == id);

        public IQueryable<ProductSize> GetSizesByProductId(int id)
            => _appContext.ProductSizes.Where(p=> p.ProductsId == id);

        private void Save(ProductSize size)
        {
            if(size.Id == default)
            {
                _appContext.Entry(size).State = EntityState.Added;
            }
            else
            {
                _appContext.Entry(size).State = EntityState.Modified;
            }

            _appContext.SaveChangesAsync();
        }
    }
}
