namespace SocialMedia.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string ContentImg { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool IsDeleted { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

    }
}
