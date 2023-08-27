using OpencartShop.Domain;
using OpencartShop.Domain.Entities;
using SQLitePCL;

namespace OpencartShop.Service.Repository.FavoriteProductsService
{
    public class FavoriteProductsService : IFavoriteProductService
    {
        private readonly AppDBContext _appDBContext;
        public FavoriteProductsService(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }
        public void AddNewFavoriteProduct(FavoriteProduct favoriteProduct)
        {
            _appDBContext.FavoriteProducts.Add(favoriteProduct);
            _appDBContext.SaveChangesAsync();
        }

        public void DeleteFavoriteProduct(int id)
        {
            var product = _appDBContext.FavoriteProducts.FirstOrDefault(p => p.ProductId == id);
            if (product is null)
            {
                return;
            }

            _appDBContext.FavoriteProducts.Remove(product);
            _appDBContext.SaveChangesAsync();
        }

        public int GetFavoriteCountByProduct(int productId)
            => _appDBContext.FavoriteProducts.Count(x => x.ProductId == productId);

        public IQueryable<FavoriteProduct> GetProductsByUser(int userId)
            => _appDBContext.FavoriteProducts.Where(x => x.CustomerId == userId);
    }
}
