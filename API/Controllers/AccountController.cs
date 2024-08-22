using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Api.Model;
using Api.Service.Repository.Auth.LoginService;
using Api.Service.Repository.Auth.RegistrationService;

namespace Api.Controllers
{
    [Route("account")]
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
        public async Task<IActionResult> Login([FromBody] UserModel user)
        {
            var token = await _loginService.Login(user.Email!, user.Password!);
            if (string.IsNullOrEmpty(token))
            {
                return Unauthorized("User is not exist");
            }
            return Ok(new
            {
                Token = token,
            });
        }

        [AllowAnonymous]
        [HttpPost("[action]")]
        public async Task<IActionResult> Registration([FromBody] RegistrationUserModel user)
        {
            try
            {
                await _registrationService.Registration(user);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

    }
}
