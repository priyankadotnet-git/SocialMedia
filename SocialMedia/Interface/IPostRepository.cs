using SocialMedia.Models;

namespace SocialMedia.Interface
{
    public interface IPostRepository
    {
        Post GetById(int postId);
        List<Post> GetAllPosts();
        List<Post> GetPostsByUser(int userId);
        void AddPost(Post post);
        void UpdatePost(Post post);
        void DeletePost(Post post);
    }
}
