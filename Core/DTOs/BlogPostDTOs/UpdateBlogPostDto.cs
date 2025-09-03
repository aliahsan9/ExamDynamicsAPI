namespace ExamDynamicsAPI.Core.DTOs.BlogPostDTOs
{
    public class UpdateBlogPostDto
    {
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public string ThumbnailUrl { get; set; } = string.Empty;
    }
}