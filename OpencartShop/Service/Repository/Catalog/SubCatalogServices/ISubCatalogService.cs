using OpencartShop.Domain.Entities;

namespace OpencartShop.Service.Repository.Catalog.SubCatalogServices
{
    public interface ISubCatalogService
    {
        Task SaveSubCatalogAsync(SubCatalog subCatalog);
        Task DeleteSubCatalogAsync(int id);
        SubCatalog? GetSubCatalogById(int id);
        IQueryable<SubCatalog> GetAllSubCatalogs();
    }
}
