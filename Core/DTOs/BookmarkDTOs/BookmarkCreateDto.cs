namespace ExamDynamicsAPI.Core.DTOs.BookmarkDTOs
{
    public class CreateBookmarkDto
    {
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public string Url { get; set; } = null!;
        public int UserId { get; set; }
        public int? ExamId { get; set; }
    }
}