using OpencartShop.Domain.Entities;

namespace OpencartShop.Service.Repository.Products.ProductColors
{
    public interface IProductColorsService
    {
        IQueryable<Color> GetAllColors();
        void AddColors(Color color);
        void EditColors(Color color);
        Color? GetColorById(int id);

        void DeleteColorById(int id);
    }
}
