namespace ExamDynamicsAPI.Core.DTOs.BlogPostDTOs
{
      public class BlogPostDto
    {
        public int BlogPostId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime PublishedAt { get; set; }
        public string AuthorId { get; set; } = string.Empty;
    }
}