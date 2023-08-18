using OpencartShop.Domain.Entities;

namespace OpencartShop.Service.Repository.Catalog
{
    public interface ICatalogManager
    {
        Task Save(IEntity category);
        Task Delete<T>(int id) where T : IEntity;
        IEntity? GetById<T>(int id) where T : IEntity;
        IQueryable<T> GetAll<T>() where T : IEntity;
    }
}
