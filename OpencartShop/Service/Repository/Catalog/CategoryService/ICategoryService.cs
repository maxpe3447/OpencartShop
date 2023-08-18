using OpencartShop.Domain.Entities;

namespace OpencartShop.Service.Repository.Catalog.CategoryService
{
    public interface ICategoryService
    {
        Task SaveCategoryAsync(Category category);
        Task DeleteCategoryAsync(int id);
        Category? GetCategoryById(int id);
        IQueryable<Category> GetAllCategories();
    }
}
