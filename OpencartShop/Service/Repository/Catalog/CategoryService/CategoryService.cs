using Microsoft.EntityFrameworkCore;
using OpencartShop.Domain;
using OpencartShop.Domain.Entities;
using OpencartShop.Service.Repository.Catalog.CatalogService;

namespace OpencartShop.Service.Repository.Catalog.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly AppDBContext _dbContext;
        public CategoryService(AppDBContext appDBContext)
        {
            _dbContext = appDBContext;
        }
        public async Task DeleteCategoryAsync(int id)
        {
            _dbContext.Categories.Remove(new Category { Id = id });
            await _dbContext.SaveChangesAsync();
        }

        public IQueryable<Category> GetAllCategories()
        {
            return _dbContext.Categories;
        }

        public Category? GetCategoryById(int id)
        {
            return _dbContext.Categories.FirstOrDefault(c => c.Id == id);
        }

        public async Task SaveCategoryAsync(Category category)
        {
            if (category.Id == default)
            {
                _dbContext.Entry(category).State = EntityState.Added;
            }
            else
            {
                _dbContext.Entry(category).State = EntityState.Modified;
            }
            await _dbContext.SaveChangesAsync();
        }
    }
}
