using Microsoft.AspNetCore.Identity;
using Api.Storage;
using Api.Storage.Entities;
using Api.Extensions;
using Api.Model;

namespace Api.Service.Repository.Auth.RegistrationService
{
    public class RegistrationService : IRegistrationService
    {
        private readonly AppDbContext _dbContext;
        private readonly UserManager<User> userManager;

        public RegistrationService(AppDbContext appDBContext, UserManager<User> userManager)
        {
            _dbContext = appDBContext;
            this.userManager = userManager;
        }
        public async Task Registration(RegistrationUserModel model)
        {
            var user = model.ToDomainUser();
            var res = await userManager.CreateAsync(user, model.Password);
            await userManager.AddToRoleAsync(user, Roles.CUSTOMER);
        }
    }
}
