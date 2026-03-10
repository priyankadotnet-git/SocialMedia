using SocialMedia.DTOs;
using SocialMedia.Interface;

namespace SocialMedia.Services
{
    public class AccountServices : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        public AccountServices(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public string IsUser(LoginDTO login)
        {
            var User = _accountRepository.GetUserByName(login.Name);
            if (User == null)
                return "";
            return "";
        }
    }
}
