using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OpencartShop.Domain.Entities;
using OpencartShop.Model;
using OpencartShop.Service.Repository.Auth.LoginService;

namespace OpencartShop.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ILoginService _loginService;
        public AccountController(ILoginService loginService)
        {
            _loginService = loginService;
        }
        [AllowAnonymous]
        [HttpPost("[action]")]
        public IResult Login([FromBody] UserModel user)
        {
            var token = _loginService.Login(user.Email!, user.Password!);
            if(string.IsNullOrEmpty(token))
            {
                return Results.BadRequest("User is not exist");
            }
            return Results.Text(token);
        }
    }
}
