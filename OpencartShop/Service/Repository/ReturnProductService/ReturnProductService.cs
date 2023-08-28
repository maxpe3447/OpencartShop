using OpencartShop.Domain;
using OpencartShop.Domain.Entities;

namespace OpencartShop.Service.Repository.ReturnProductService
{
    public class ReturnProductService : IReturnProductService
    {
        private readonly AppDBContext _dbContext;
        public ReturnProductService(AppDBContext appDBContext)
        {
            _dbContext = appDBContext;
        }
        public void Add(ReturnProduct product)
        {
            _dbContext.ReturnProducts.Add(product);
            _dbContext.SaveChanges();
        }

        public void Cancel(int id)
        {
            var product = _dbContext.ReturnProducts.FirstOrDefault(x => x.Id == id);
            if (product is null)
            {
                return;
            }
            product.IsActive = false;
            _dbContext.SaveChanges();
        }

        public IQueryable<ReturnProduct> GetAll() => _dbContext.ReturnProducts;

        public ReturnProduct GetByOrderId(int id)
            => _dbContext.ReturnProducts.FirstOrDefault(x => x.Id == id) ?? new();

        public ReturnProduct GetByPhoneEmail(string phoneEmail)
            => _dbContext.ReturnProducts.FirstOrDefault(x => x.PhoneOrEmail == phoneEmail) ?? new();
    }
}
