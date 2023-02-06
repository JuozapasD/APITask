using APITask.BL.Services;
using APITask.DTO;
using Microsoft.AspNetCore.Mvc;

namespace APITask.Controllers
{
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService _accountsService;
        private readonly IJwtService _jwtService;
        public AccountsController(IAccountService accountsService, IJwtService jwtService)
        {
            _accountsService = accountsService;
            _jwtService = jwtService;
        }

        [HttpPost("SignUp")]
        public ActionResult SignUp([FromBody] AuthRequestDto request)
        {
            _accountsService.SignupNewAccount(request.UserName, request.Password);
            return Ok();
        }

        [HttpPost("Login")]
        public ActionResult Login([FromBody] AuthRequestDto request)
        {
            var (loginSuccess, account) = _accountsService.Login(request.UserName, request.Password);
            if (!loginSuccess)
            {
                return BadRequest("Invalid username or password");
            }
            else
            {
                var jwt = _jwtService.GetJwtToken(account.Username, account.Id, account.Role);
                return Ok(jwt);
            }
        }

    }
}
