using OpencartShop.Domain.Entities;

namespace OpencartShop.Service.Repository.Catalog.CatalogService
{
    public interface ICatalogService
    {
        Task SaveCatalogAsync(Domain.Entities.Catalog catalog);
        Task DeleteCatalogAsync(int id);
        Domain.Entities.Catalog? GetCatalogById(int id);
        IQueryable<Domain.Entities.Catalog> GetAllCatalogs();
    }
}
