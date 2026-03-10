using SocialMedia.DTOs;
using SocialMedia.Models;

namespace SocialMedia.Interface
{
    public interface IProfileService 
    {
        ProfileResponseDTO GetUserById(int id);
        //bool UpdateUserProfile(UpdateProfileDTO updateProfileDTO);
        ProfileResponseDTO UpdateProfile(int userId, UpdateProfileDTO dto);
    }
}
