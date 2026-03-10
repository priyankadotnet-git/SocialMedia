using Microsoft.AspNetCore.Mvc;
using SocialMedia.DTOs;
using SocialMedia.Interface;

namespace SocialMedia.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        public IActionResult Login(LoginDTO login)
        {
            if (login == null)
                return BadRequest();
            if (login.Name == null || login.Password ==null)
                return BadRequest();
            bool authenticatedUser = _accountService.IsUser(login);
            return View();
        }
    }
}
