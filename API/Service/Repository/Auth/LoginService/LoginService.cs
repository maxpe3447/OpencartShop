using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Api.Storage;
using Api.Storage.Entities;
using Api.Helpers;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Api.Service.Repository.Auth.LoginService
{
    public class LoginService : ILoginService
    {
        private readonly SymmetricSecurityKey _key;
        private readonly AppDbContext _dbContext;
        private readonly UserManager<User> userManager;

        public LoginService(AppDbContext appDBContext, UserManager<User> userManager, IConfiguration configuration)
        {

            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["TokenKey"]!));
            _dbContext = appDBContext;
            this.userManager = userManager;
        }
        public async Task<string> Login(string mail, string password)
        {
            var user = _dbContext.Users
                .AsNoTracking()
                .Include(u=>u.UserRoles).ThenInclude(ur=>ur.Role)
                .FirstOrDefault(x => x.Email == mail);
            if (user is null)
            {
                return string.Empty;
            }

            if (!await userManager.CheckPasswordAsync(user, password))
            {
                return string.Empty;
            }

            var claims = new List<Claim> {
                new Claim("userId", user.Id.ToString()) ,
                new Claim("roles", string.Join(",", user.UserRoles?.Select(ur=>ur.Role.Name), Array.Empty<string>()))
            };
            var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

            var jwt = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.Add(TimeSpan.FromDays(7)),
                signingCredentials: creds);

            var encodeJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            return encodeJwt;
        }
    }
}
