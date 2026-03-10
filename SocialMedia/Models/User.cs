namespace SocialMedia.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string HashedPassword { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public int AccountType { get; set; }
    }
}
