using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OpencartShop.Domain.Entities;
using OpencartShop.Model;
using OpencartShop.Service.Repository.Auth.LoginService;
using OpencartShop.Service.Repository.Auth.RegistrationService;
using System.Reflection.Metadata.Ecma335;

namespace OpencartShop.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ILoginService _loginService;
        private readonly IRegistrationService _registrationService;
        public AccountController(ILoginService loginService,
                                 IRegistrationService registrationService)
        {
            _loginService = loginService;
            _registrationService = registrationService;
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

        [AllowAnonymous]
        [HttpPost("[action]")]
        public IResult Registration([FromBody] RegistrationUserModel user)
        {
            try
            {
                var userId = _registrationService.Registration(user);
                return Results.Json(new {UserId=userId});
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
            
        }

    }
}
