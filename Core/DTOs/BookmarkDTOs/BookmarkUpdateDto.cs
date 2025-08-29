namespace ExamDynamicsAPI.Core.DTOs.BookmarkDTOs
{
    public class UpdateBookmarkDto
    {
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public string Url { get; set; } = null!;
    }
}