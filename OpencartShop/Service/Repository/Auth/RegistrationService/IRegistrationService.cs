using OpencartShop.Model;

namespace OpencartShop.Service.Repository.Auth.RegistrationService
{
    public interface IRegistrationService
    {
        int Registration(RegistrationUserModel model);
    }
}
