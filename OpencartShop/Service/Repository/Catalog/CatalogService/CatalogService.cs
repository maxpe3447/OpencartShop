using Microsoft.EntityFrameworkCore;
using OpencartShop.Domain;

namespace OpencartShop.Service.Repository.Catalog.CatalogService
{
    public class CatalogService : ICatalogService
    {
        private readonly AppDBContext _dbContext;
        public CatalogService(AppDBContext appDBContext)
        {
            _dbContext = appDBContext;
        }

        public async Task DeleteCatalogAsync(int id)
        {
            _dbContext.Catalog.Remove(new Domain.Entities.Catalog { Id = id });
            await _dbContext.SaveChangesAsync();
        }

        public IQueryable<Domain.Entities.Catalog> GetAllCatalogs() =>
            _dbContext.Catalog.Include(c => c.SubCatalogs)
                                .ThenInclude(c => c.Categories);

        public Domain.Entities.Catalog? GetCatalogById(int id)
            => _dbContext.Catalog.FirstOrDefault(c => c.Id == id);

        public async Task SaveCatalogAsync(Domain.Entities.Catalog catalog)
        {
            if (catalog.Id == default)
            {
                _dbContext.Entry(catalog).State = EntityState.Added;
            }
            else
            {
                _dbContext.Entry(catalog).State = EntityState.Modified;
            }
            await _dbContext.SaveChangesAsync();
        }
    }
}
