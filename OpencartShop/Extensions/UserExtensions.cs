using OpencartShop.Domain.Entities;
using OpencartShop.Helpers;
using OpencartShop.Model;

namespace OpencartShop.Extensions
{
    public static class UserExtensions
    {
        public static User ToDomainUser(this RegistrationUserModel user)
            => new User() { IsAdmin = false, PasswordHash = AuthConfigs.GetPasswordHash(user.Password) };

        public static Customer ToDomainCustomer(this RegistrationUserModel user)
            => new Customer
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user?.Email ?? string.Empty,
                Phone = user?.Phone ?? string.Empty,
            };
    }
}
