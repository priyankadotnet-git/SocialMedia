using SocialMedia.DTOs;
using SocialMedia.Interface;
using SocialMedia.Models;

namespace SocialMedia.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;

        public PostService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public PostResponseDTO CreatePost(CreatePostDTO dto, int userId)
        {
            var post = new Post
            {
                Content = dto.Content,
                UserId = userId
            };

            _postRepository.AddPost(post);

            var saved = _postRepository.GetById(post.Id);
            return MapToResponse(saved);
        }

        public List<PostResponseDTO> GetAllPosts()
        {
            return _postRepository.GetAllPosts()
                .Select(p => MapToResponse(p))
                .ToList();
        }

        public List<PostResponseDTO> GetPostsByUser(int userId)
        {
            return _postRepository.GetPostsByUser(userId)
                .Select(p => MapToResponse(p))
                .ToList();
        }

        public PostResponseDTO UpdatePost(int postId, UpdatePostDTO dto, int userId)
        {
            var post = _postRepository.GetById(postId);

            if (post == null) return null;

            // ✅ Only owner can update
            if (post.UserId != userId) return null;

            post.Content = dto.Content;
            post.UpdatedOn = DateTime.UtcNow;

            _postRepository.UpdatePost(post);
            return MapToResponse(post);
        }

        public bool DeletePost(int postId, int userId)
        {
            var post = _postRepository.GetById(postId);

            if (post == null) return false;

            // ✅ Only owner can delete
            if (post.UserId != userId) return false;

            _postRepository.DeletePost(post);
            return true;
        }

        // ✅ Helper method
        private PostResponseDTO MapToResponse(Post post)
        {
            return new PostResponseDTO
            {
                Id = post.Id,
                Content = post.Content,
                Username = post.User.Username,
                ProfilePicture = post.User.ProfilePicture,
                UserId = post.UserId,
                CreatedAt = post.CreatedOn,
                UpdatedAt = post.UpdatedOn
            };
        }
    }
}
