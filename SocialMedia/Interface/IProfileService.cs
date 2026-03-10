using SocialMedia.Models;

namespace SocialMedia.Interface
{
    public interface IProfileService 
    {
        User GetUserById(int id);
    }
}
