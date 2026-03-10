using Microsoft.AspNetCore.Http.HttpResults;
using SocialMedia.DTOs;
using SocialMedia.Extensions;
using SocialMedia.Interface;
using SocialMedia.Models;

namespace SocialMedia.Services
{
    public class AccountServices : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly JwtService _jwtService;
        public AccountServices(IAccountRepository accountRepository, JwtService jwtService)
        {
            _accountRepository = accountRepository;
            _jwtService = jwtService;
        }

        

        public User IsUser(LoginDTO login)
        {
             return _accountRepository.GetUserByName(login.Name);
        }
        public string GenerateToken(User user)
        {
            string token = _jwtService.GenerateToken(user);
            return token;
        }

        public bool RegisterUser(RegisterDTO register)
        {
            var Exsists = _accountRepository.GetUserByName(register.Username);
            if (Exsists != null)
                return false;
            register.Password = CheckPassword.HashPassword(register.Password);
            bool success = _accountRepository.SaveUser(register);
            throw new NotImplementedException();
        }
    }
}
