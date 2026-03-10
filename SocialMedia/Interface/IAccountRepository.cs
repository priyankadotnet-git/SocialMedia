

using SocialMedia.Models;

namespace SocialMedia.Interface
{
    public interface IAccountRepository
    {
        User GetUserByName(string UserName);
    }
}
