using Microsoft.AspNetCore.Mvc;
using SocialMedia.DTOs;
using SocialMedia.Extensions;
using SocialMedia.Interface;
using SocialMedia.Models;

namespace SocialMedia.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDTO login)
        {
            if (login == null || login.Name == null || login.Password == null)
                return BadRequest("Invalid input");
            var User = _accountService.IsUser(login);
            if (User == null)
                return Unauthorized("Invalid User");
            if(!CheckPassword.VerifyPassword(login.Password, User.HashedPassword))
                return Unauthorized("Invalid Username or password");
            string token = _accountService.GenerateToken(User);

            var res = new
            {
                token = token,
                UserName = login.Name,
                UserId = User.Id,
                expiresIn = "60 minutes"
            };

            return Ok(res);
        }
        [HttpPost("Register")]
        public IActionResult Register([FromBody] RegisterDTO newUser)
        {
            if (newUser == null)
                return BadRequest("Informations not found");
            bool success = _accountService.RegisterUser(newUser);
            if (!success)
                return Conflict("UserName already exsists");
            return Ok("User Created Successfully");
        }
    }
}
