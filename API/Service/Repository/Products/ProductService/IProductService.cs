using Api.Storage.Entities;

namespace Api.Service.Repository.Products.ProductService
{
    public interface IProductService
    {
        IQueryable<Product> GetAllProducts();
        IQueryable<Product> GetAllProductsByCategoryId(int id);
        void AddProduct(Product product);
        void EditProduct(Product product);
        Product? GetProductById(int id);


        void DeleteProductById(int id);
    }
}
