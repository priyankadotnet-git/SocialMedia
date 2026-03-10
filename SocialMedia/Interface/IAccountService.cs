using SocialMedia.DTOs;

namespace SocialMedia.Interface
{
    public interface IAccountService
    {
        string IsUser(LoginDTO login);
    }
}
