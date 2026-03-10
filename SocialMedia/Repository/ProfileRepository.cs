using SocialMedia.Data;
using SocialMedia.Interface;
using SocialMedia.Models;

namespace SocialMedia.Repository
{
    public class ProfileRepository : IProfileRepository
    {
        private readonly AppDbContext _context;
        public ProfileRepository(AppDbContext context)
        {
            _context = context;
        }
        public User GetUserById(int id)
        {
            return _context.Users.FirstOrDefault(x => x.Id == id);
        }
    }
}
