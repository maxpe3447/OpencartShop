using OpencartShop.Domain.Entities;

namespace OpencartShop.Service.Repository.FavoriteProductsService
{
    public interface IFavoriteProductService
    {
        void AddNewFavoriteProduct(FavoriteProduct favoriteProduct);
        void DeleteFavoriteProduct(int id);
        IQueryable<FavoriteProduct> GetProductsByUser(int userId);
        int GetFavoriteCountByProduct(int productId);
    }
}
