using AutoMapper;
using ExamDynamicsAPI.Core.DTOs.BlogPostDTOs;
using ExamDynamicsAPI.Core.Interfaces.Repositories;
using ExamDynamicsAPI.Core.Interfaces.Services;
using ExamDynamicsAPI.Core.Models;

namespace ExamDynamicsAPI.Applications.Services
{
    public class BlogPostService : IBlogPostService
    {
        private readonly IBlogPostRepository _blogPostRepository;
        private readonly IMapper _mapper;

        public BlogPostService(IBlogPostRepository blogPostRepository, IMapper mapper)
        {
            _blogPostRepository = blogPostRepository;
            _mapper = mapper;
        }

        // ================= GET ALL =================
        public async Task<IEnumerable<BlogPostDto>> GetAllAsync()
        {
            var blogPosts = await _blogPostRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<BlogPostDto>>(blogPosts);
        }

        // ================= GET BY ID =================
        public async Task<BlogPostDto?> GetByIdAsync(int id)
        {
            var blogPost = await _blogPostRepository.GetByIdAsync(id);
            return _mapper.Map<BlogPostDto?>(blogPost);
        }

        // ================= GET PUBLISHED POSTS =================
        public async Task<IEnumerable<BlogPostDto>> GetPublishedPostsAsync()
        {
            var publishedPosts = await _blogPostRepository.GetPublishedPostsAsync();
            return _mapper.Map<IEnumerable<BlogPostDto>>(publishedPosts);
        }

        // ================= GET POSTS BY AUTHOR =================
        public async Task<IEnumerable<BlogPostDto>> GetPostsByAuthorAsync(int authorId)
        {
            var posts = await _blogPostRepository.GetPostsByAuthorAsync(authorId);
            return _mapper.Map<IEnumerable<BlogPostDto>>(posts);
        }

        // ================= CREATE =================
        public async Task<BlogPostDto> CreateAsync(CreateBlogPostDto dto, int authorId)
        {
            var blogPost = _mapper.Map<BlogPost>(dto);

            // Assign author and default values
            blogPost.AuthorId = authorId;
            blogPost.PublishedAt = DateTime.UtcNow;
            blogPost.IsPublished = true;

            await _blogPostRepository.AddAsync(blogPost);
            return _mapper.Map<BlogPostDto>(blogPost);
        }

        // ================= UPDATE =================
        public async Task<bool> UpdateAsync(int id, UpdateBlogPostDto dto)
        {
            var existing = await _blogPostRepository.GetByIdAsync(id);
            if (existing == null) return false;

            _mapper.Map(dto, existing);
            await _blogPostRepository.UpdateAsync(existing);
            return true;
        }

        // ================= DELETE =================
        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await _blogPostRepository.GetByIdAsync(id);
            if (existing == null) return false;

            await _blogPostRepository.DeleteAsync(existing.BlogPostId);
            return true;
        }
    }
}
