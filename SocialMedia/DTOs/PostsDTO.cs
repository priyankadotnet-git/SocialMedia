namespace SocialMedia.DTOs
{
    public class CreatePostDTO
    {
        public string Content { get; set; }
        public string ContentImg { get; set; }
    }

    public class UpdatePostDTO
    {
        public string Content { get; set; }
        public string ContentImg { get; set; }
    }

    public class PostResponseDTO
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string Username { get; set; }
        public string ProfilePicture { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
