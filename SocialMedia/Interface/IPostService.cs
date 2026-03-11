using SocialMedia.DTOs;

namespace SocialMedia.Interface
{
    public interface IPostService
    {
        PostResponseDTO CreatePost(CreatePostDTO dto, int userId);
        List<PostResponseDTO> GetAllPosts();
        List<PostResponseDTO> GetPostsByUser(int userId);
        PostResponseDTO UpdatePost(int postId, UpdatePostDTO dto, int userId);
        bool DeletePost(int postId, int userId);
    }
}
