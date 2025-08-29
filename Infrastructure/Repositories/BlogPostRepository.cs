using ExamDynamicsAPI.Core.Interfaces.Repositories;
using ExamDynamicsAPI.Core.Models;
using ExamDynamicsAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ExamDynamicsAPI.Infrastructure.Repositories
{
    public class BlogPostRepository : GenericRepository<BlogPost>, IBlogPostRepository
    {
        public BlogPostRepository(ExamDynamicsDbContext context) : base(context)
        {
        }

        // Get all published blog posts
        public async Task<IEnumerable<BlogPost>> GetPublishedPostsAsync()
        {
            return await _context.BlogPosts
                                 .Where(bp => bp.IsPublished)
                                 .AsNoTracking()
                                 .ToListAsync();
        }

        // Get posts by a specific author
        public async Task<IEnumerable<BlogPost>> GetPostsByAuthorAsync(int authorId)
        {
            return await _context.BlogPosts
                                 .Where(bp => bp.AuthorId == authorId) // ✅ Correct property
                                 .AsNoTracking()
                                 .ToListAsync();
        }
    }
}
