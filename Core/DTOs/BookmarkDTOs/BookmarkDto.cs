namespace ExamDynamicsAPI.Core.DTOs.BookmarkDTOs
{
    public class BookmarkDto
    {
        public int BookmarkId { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public string Url { get; set; } = null!;
        public int UserId { get; set; }
        public int? ExamId { get; set; }
    }
}