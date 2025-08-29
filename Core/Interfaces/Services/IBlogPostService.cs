using ExamDynamicsAPI.Core.DTOs.BlogPostDTOs;

namespace ExamDynamicsAPI.Core.Interfaces.Services
{
    public interface IBlogPostService
    {
        Task<IEnumerable<BlogPostDto>> GetAllAsync();
        Task<BlogPostDto?> GetByIdAsync(int id);
        Task<IEnumerable<BlogPostDto>> GetPublishedPostsAsync();

        // Change authorId type to string
        Task<IEnumerable<BlogPostDto>> GetPostsByAuthorAsync(int authorId);

        Task<BlogPostDto> CreateAsync(CreateBlogPostDto dto, int authorId);
        Task<bool> UpdateAsync(int id, UpdateBlogPostDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
