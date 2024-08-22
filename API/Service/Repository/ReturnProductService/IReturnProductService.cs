using Api.Storage;
using Api.Storage.Entities;

namespace Api.Service.Repository.ReturnProductService
{
    public interface IReturnProductService
    {
        IQueryable<ReturnProduct> GetAll();
        ReturnProduct GetByOrderId(int id);
        void Add(ReturnProduct product);
        void Cancel(int id);
        ReturnProduct GetByPhoneEmail(string phoneEmail);
    }
}
