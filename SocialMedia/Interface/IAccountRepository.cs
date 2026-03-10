

using SocialMedia.DTOs;
using SocialMedia.Models;

namespace SocialMedia.Interface
{
    public interface IAccountRepository
    {
        User GetUserByName(string UserName);
        bool SaveUser(RegisterDTO Register);
    }
}
