using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.IdentityModel.Tokens;
using OpencartShop.Domain;
using OpencartShop.Helpers;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace OpencartShop.Service.Repository.Auth.LoginService
{
    public class LoginService : ILoginService
    {
        private readonly AppDBContext _dbContext;
        public LoginService(AppDBContext appDBContext)
        {
            _dbContext = appDBContext;
        }
        public string Login(string mail, string password)
        {
            var customer = _dbContext.Customers.FirstOrDefault(x => x.Email == mail);
            if (customer is null)
            {
                return string.Empty;
            }
            var passwordHash = AuthConfigs.GetPasswordHash(password);
            Console.WriteLine("3 ->" + passwordHash);

            var user = _dbContext.Users.FirstOrDefault(u=>u.PasswordHash == passwordHash);
            if (user is null)
            {
                return string.Empty;
            }

            var claims = new List<Claim> { new Claim("userId", user.Id.ToString()) };

            var jwt = new JwtSecurityToken(
                issuer: AuthConfigs.ISSUER,
                audience: AuthConfigs.AUDIENCE,
                claims: claims,
                expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(30)),
                signingCredentials: new SigningCredentials(AuthConfigs.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodeJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            return encodeJwt;
        }
    }
}
