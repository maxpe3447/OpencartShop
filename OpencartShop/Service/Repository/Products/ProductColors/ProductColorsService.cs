using Microsoft.EntityFrameworkCore;
using OpencartShop.Domain;
using OpencartShop.Domain.Entities;

namespace OpencartShop.Service.Repository.Products.ProductColors
{
    public class ProductColorsService : IProductColorsService
    {
        private readonly AppDBContext _dbContext;
        public ProductColorsService(AppDBContext appDBContext)
        {
            _dbContext = appDBContext;
        }
        public void AddColors(Color color) => SaveColor(color);

        public void Bind(int colorId, int productId)
        {
            _dbContext.ProductColors.Add(new ProductColor { ColorsId = colorId, ProductId = productId});
        }

        public void DeleteColorById(int id) 
            => _dbContext.Colors.Remove(new Color { Id = id });

        public void EditColors(Color color) => SaveColor(color);

        public IQueryable<Color> GetAllColors() => _dbContext.Colors;

        public Color? GetColorById(int id) => 
            _dbContext.Colors.FirstOrDefault(c => c.Id == id);

        public void RemoveBind(int id)
        {
            _dbContext.ProductColors.Remove(new ProductColor { Id = id });
        }

        private void SaveColor(Color color)
        {
            if (color.Id == default)
            {
                _dbContext.Entry(color).State = EntityState.Added;
            }
            else
            {
                _dbContext.Entry(color).State = EntityState.Modified;
            }

            _dbContext.SaveChangesAsync();
        }
    }
}
