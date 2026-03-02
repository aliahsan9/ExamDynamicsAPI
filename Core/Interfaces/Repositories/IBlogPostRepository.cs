using ExamDynamicsAPI.Core.Models;

namespace ExamDynamicsAPI.Core.Interfaces.Repositories
{
    public interface IBlogPostRepository : IGenericRepository<BlogPost>
    {
        Task<IEnumerable<BlogPost>> GetPublishedPostsAsync();

        // Change int to string
        Task<IEnumerable<BlogPost>> GetPostsByAuthorAsync(int authorId);
    }
}
