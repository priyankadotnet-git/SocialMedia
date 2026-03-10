using SocialMedia.DTOs;
using SocialMedia.Interface;
using SocialMedia.Models;

namespace SocialMedia.Services
{
    public class ProfileServices : IProfileService
    {
        private readonly IProfileRepository _profileRepository;
        public ProfileServices(IProfileRepository profileRepository)
        { 
            _profileRepository = profileRepository;
        }
        public ProfileResponseDTO  GetUserById(int id)
        {
            var user = _profileRepository.GetUserById(id);

            if (user == null) return null;

            return new ProfileResponseDTO
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                Bio = user.Bio,
                ProfilePicture = user.ProfilePicture,
                CreatedAt = user.CreatedOn,
                TotalPosts = user.Posts?.Count ?? 0
            };
        }
        public ProfileResponseDTO UpdateProfile(int userId, UpdateProfileDTO dto)
        {
            var user = _profileRepository.GetUserById(userId);

            if (user == null) return null;

            // Only update fields that are provided
            if (!string.IsNullOrEmpty(dto.Bio))
                user.Bio = dto.Bio;

            if (!string.IsNullOrEmpty(dto.ProfilePicture))
                user.ProfilePicture = dto.ProfilePicture;

            if (!string.IsNullOrEmpty(dto.Email))
                user.Email = dto.Email;

            _profileRepository.UpdateProfile(user);

            return GetUserById(userId);
        }
        //public bool UpdateUserProfile(UpdateProfileDTO updateProfile)
        //{
        //    User user = _profileRepository.GetUserById(updateProfile.Id);
        //    if (user == null)
        //        return false;

        //    user.Email = updateProfile.Email;
        //    user.Bio = updateProfile.Bio;
        //    user.ProfilePicture = updateProfile.ProfilePicture;
        //    user.Username = updateProfile.Name;
        //    bool IsUpdated = _profileRepository.UpdateProfile(user);
        //    return IsUpdated;
        //}
    }
}
