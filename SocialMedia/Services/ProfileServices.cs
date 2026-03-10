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
        public User GetUserById(int id)
        {
            return _profileRepository.GetUserById(id);
        }
    }
}
