namespace SocialMedia.DTOs
{
    public class ProfileResponseDTO
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Bio { get; set; }
        public string ProfilePicture { get; set; }
        public DateTime CreatedAt { get; set; }
        public int TotalPosts { get; set; }
        public int TotalFollowers { get; set; }
        public int TotalFollowing { get; set; }
    }
}
