using OpencartShop.Domain.Entities;

namespace OpencartShop.Service.Repository.Products.ProductSizes
{
    public interface IProductSizesService
    {
        IQueryable<ProductSize> GetAllSizes();
        IQueryable<ProductSize> GetSizesByProductId(int id);
        void AddSize(ProductSize size);
        void EditSize(ProductSize size);
        ProductSize? GetSizeById(int id);


        void DeleteSizeById(int id);
    }
}
