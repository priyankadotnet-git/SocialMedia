using SocialMedia.Models;

namespace SocialMedia.Interface
{
    public interface IProfileRepository
    {
        User GetUserById(int id);
    }
}
