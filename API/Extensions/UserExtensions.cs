using Api.Storage.Entities;
using Api.Helpers;
using Api.Model;

namespace Api.Extensions
{
    public static class UserExtensions
    {
        public static User ToDomainUser(this RegistrationUserModel user)
            => new User
            {
                UserName = user.Username,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user?.Email ?? string.Empty,
                Phone = user?.Phone ?? string.Empty,
            };
    }
}
