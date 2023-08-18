using Microsoft.EntityFrameworkCore;
using OpencartShop.Domain;
using OpencartShop.Domain.Entities;

namespace OpencartShop.Service.Repository.Catalog.SubCatalogServices
{
    public class SubCatalogService : ISubCatalogService
    {
        private readonly AppDBContext _dbContext;
        public SubCatalogService(AppDBContext appDBContext)
        {
            _dbContext = appDBContext;
        }
        public async Task DeleteSubCatalogAsync(int id)
        {
            _dbContext.SubCatalog.Remove(new SubCatalog { Id = id });
            await _dbContext.SaveChangesAsync();
        }

        public IQueryable<SubCatalog> GetAllSubCatalogs()
        {
            return _dbContext.SubCatalog.Include(s => s.Categories);
        }

        public SubCatalog? GetSubCatalogById(int id)
        {
            return _dbContext.SubCatalog.FirstOrDefault(s => s.Id == id);
        }

        public async Task SaveSubCatalogAsync(SubCatalog subCatalog)
        {
            if (subCatalog.Id == default)
            {
                _dbContext.Entry(subCatalog).State = EntityState.Added;
            }
            else
            {
                _dbContext.Entry(subCatalog).State = EntityState.Modified;
            }
            await _dbContext.SaveChangesAsync();
        }
    }
}
