using SocialMedia.Data;
using SocialMedia.DTOs;
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

        public bool SaveUser(RegisterDTO register)
        {
            if (register == null)
                return false;
            User user = new User() { 
                Username = register.Username,
                Email = register.Email,
                HashedPassword = register.Password,
                IsActive = true
            };
            _context.Users.Add(user);
            _context.SaveChanges();
            return true;
        }
    }
}
