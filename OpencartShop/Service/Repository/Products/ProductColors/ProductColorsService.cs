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
        public void AddColors(Colors color) => SaveColor(color);

        public void DeleteColorById(int id) 
            => _dbContext.Colors.Remove(new Colors { Id = id });

        public void EditColors(Colors color) => SaveColor(color);

        public IQueryable<Colors> GetAllColors() => _dbContext.Colors;

        public Colors? GetColorById(int id) => 
            _dbContext.Colors.FirstOrDefault(c => c.Id == id);


        private void SaveColor(Colors color)
        {
            if (color.Id == default)
            {
                _dbContext.Entry(color).State = EntityState.Added;
                return;
            }

            _dbContext.Entry(color).State = EntityState.Modified;
        }
    }
}
