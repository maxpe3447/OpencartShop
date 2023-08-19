using OpencartShop.Domain.Entities;

namespace OpencartShop.Service.Repository.Products.ProductColors
{
    public interface IProductColorsService
    {
        IQueryable<Colors> GetAllColors();
        void AddColors(Colors color);
        void EditColors(Colors color);
        Colors? GetColorById(int id);

        void DeleteColorById(int id);
    }
}
