using SocialMedia.Data;
using SocialMedia.Interface;
using SocialMedia.Models;

namespace SocialMedia.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly AppDbContext _context;
        public AccountRepository(AppDbContext context)
        {
            _context = context;
        }
        public User GetUserByName(string UserName)
        {
            return _context.Users.FirstOrDefault(x => x.Username == UserName);
        }
    }
}
