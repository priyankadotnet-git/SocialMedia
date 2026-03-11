using Microsoft.EntityFrameworkCore;
using SocialMedia.Data;
using SocialMedia.Interface;
using SocialMedia.Models;

namespace SocialMedia.Repository
{
    public class PostRepository : IPostRepository
    {
        private readonly AppDbContext _context;

        public PostRepository(AppDbContext context)
        {
            _context = context;
        }

        public Post GetById(int postId)
        {
            return _context.Posts
                .Include(p => p.User)
                .FirstOrDefault(p => p.Id == postId && !p.IsDeleted);
        }

        public List<Post> GetAllPosts()
        {
            return _context.Posts
                .Include(p => p.User)
                .Where(p => !p.IsDeleted)
                .OrderByDescending(p => p.CreatedOn)
                .ToList();
        }

        public List<Post> GetPostsByUser(int userId)
        {
            return _context.Posts
                .Include(p => p.User)
                .Where(p => p.UserId == userId && !p.IsDeleted)
                .OrderByDescending(p => p.CreatedOn)
                .ToList();
        }

        public void AddPost(Post post)
        {
            _context.Posts.Add(post);
            _context.SaveChanges();
        }

        public void UpdatePost(Post post)
        {
            _context.Posts.Update(post);
            _context.SaveChanges();
        }

        public void DeletePost(Post post)
        {
            // Soft delete - keep in DB but hide
            post.IsDeleted = true;
            _context.Posts.Update(post);
            _context.SaveChanges();
        }
    }
}
