using OpencartShop.Domain;
using OpencartShop.Helpers;
using OpencartShop.Model;

namespace OpencartShop.Service.Repository.Auth.RegistrationService
{
    public class RegistrationService : IRegistrationService
    {
        private readonly AppDBContext _dbContext;
        public RegistrationService(AppDBContext appDBContext)
        {
            _dbContext = appDBContext;
        }
        public int Registration(RegistrationUserModel model)
        {
            var user = model.ToDomainUser();
            var customer = model.ToDomainCustomer();
            user.Customers = customer;

            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
            return customer.Id;
        }
    }
}
