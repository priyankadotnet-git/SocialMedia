using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.DTOs;
using SocialMedia.Interface;

namespace SocialMedia.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class PostController : Controller
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        private int GetUserId() =>
            int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

        // GET /api/post/all
        [HttpGet("all")]
        public IActionResult GetAllPosts()
        {
            var posts = _postService.GetAllPosts();
            return Ok(posts);
        }

        // GET /api/post/user/{userId}
        [HttpGet("user/{userId}")]
        public IActionResult GetPostsByUser(int userId)
        {
            var posts = _postService.GetPostsByUser(userId);
            return Ok(posts);
        }

        // GET /api/post/myposts
        [HttpGet("myposts")]
        public IActionResult GetMyPosts()
        {
            var posts = _postService.GetPostsByUser(GetUserId());
            return Ok(posts);
        }

        // POST /api/post/create
        [HttpPost("create")]
        public IActionResult CreatePost([FromBody] CreatePostDTO dto)
        {
            if (dto == null || string.IsNullOrEmpty(dto.Content))
                return BadRequest("Content cannot be empty");

            var post = _postService.CreatePost(dto, GetUserId());
            return Ok(post);
        }

        // PUT /api/post/update/{postId}
        [HttpPut("update/{postId}")]
        public IActionResult UpdatePost(int postId, [FromBody] UpdatePostDTO dto)
        {
            var updated = _postService.UpdatePost(postId, dto, GetUserId());

            if (updated == null)
                return NotFound("Post not found or you dont have permission");

            return Ok(updated);
        }

        // DELETE /api/post/delete/{postId}
        [HttpDelete("delete/{postId}")]
        public IActionResult DeletePost(int postId)
        {
            bool success = _postService.DeletePost(postId, GetUserId());

            if (!success)
                return NotFound("Post not found or you dont have permission");

            return Ok("Post deleted successfully");
        }
    }
}
