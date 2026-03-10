using SocialMedia.DTOs;
using SocialMedia.Models;

namespace SocialMedia.Interface
{
    public interface IAccountService
    {
        User IsUser(LoginDTO login);
        bool RegisterUser(RegisterDTO register);
        string GenerateToken(User user);
    }
}
