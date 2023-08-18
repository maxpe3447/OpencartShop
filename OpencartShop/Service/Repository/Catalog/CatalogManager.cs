using Microsoft.EntityFrameworkCore;
using OpencartShop.Domain;
using OpencartShop.Domain.Entities;
using OpencartShop.Service.Repository.Catalog.CatalogService;
using OpencartShop.Service.Repository.Catalog.CategoryService;
using OpencartShop.Service.Repository.Catalog.SubCatalogServices;

namespace OpencartShop.Service.Repository.Catalog
{
    public class CatalogManager : ICatalogManager
    {
        private readonly ICatalogService _catalogService;
        private readonly ICategoryService _categoryService;
        private readonly ISubCatalogService _subCatalogService;
        public CatalogManager(ICatalogService catalogService,
                              ICategoryService categoryService,
                              ISubCatalogService subCatalogService)
        {
            _categoryService = categoryService;
            _catalogService = catalogService;
            _subCatalogService = subCatalogService;
        }

        public async Task Delete<T>(int id) where T : IEntity
        {
            if (typeof(T) == typeof(Domain.Entities.Catalog))
            {
                await _catalogService.DeleteCatalogAsync(id);
            }
            else if (typeof(T) == typeof(Category))
            {
                await _categoryService.DeleteCategoryAsync(id);
            }
            else if (typeof(T) == typeof(SubCatalog))
            {
                await _subCatalogService.DeleteSubCatalogAsync(id);
            }
        }

        public IQueryable<T> GetAll<T>() where T : IEntity
        {
            if (typeof(T) == typeof(Domain.Entities.Catalog))
            {
                return (IQueryable<T>)_catalogService.GetAllCatalogs();
            }
            else if (typeof(T) == typeof(Category))
            {
                return (IQueryable<T>)_categoryService.GetAllCategories();
            }
            else if (typeof(T) == typeof(SubCatalog))
            {
                return (IQueryable<T>)_subCatalogService.GetAllSubCatalogs();
            }

            throw new ArgumentException($"Unknown generic type {nameof(T)}");
        }

        public IEntity? GetById<T>(int id) where T : IEntity
        {
            if (typeof(T) == typeof(Domain.Entities.Catalog))
            {
                return _catalogService.GetCatalogById(id);
            }
            else if (typeof(T) == typeof(Category))
            {
                return _categoryService.GetCategoryById(id);
            }
            else if (typeof(T) == typeof(SubCatalog))
            {
                return _subCatalogService.GetSubCatalogById(id);
            }

            throw new ArgumentException($"Unknown generic type {nameof(T)}");
        }

        public async Task Save(IEntity entity)
        {
            if (entity is Domain.Entities.Catalog catalog)
            {
                await _catalogService.SaveCatalogAsync(catalog);
            }
            else if (entity is Category categoy)
            {
                await _categoryService.SaveCategoryAsync(categoy);
            }
            else if (entity is SubCatalog sub)
            {
                await _subCatalogService.SaveSubCatalogAsync(sub);
            }

            throw new ArgumentException($"Unknown generic type {nameof(entity)}");
        }
    }
}
