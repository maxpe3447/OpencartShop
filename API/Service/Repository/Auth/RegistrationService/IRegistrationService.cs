using Api.Model;

namespace Api.Service.Repository.Auth.RegistrationService;

public interface IRegistrationService
{
    Task Registration(RegistrationUserModel model);
}
