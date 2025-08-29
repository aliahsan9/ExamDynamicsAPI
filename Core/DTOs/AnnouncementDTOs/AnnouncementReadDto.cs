using System;

namespace ExamDynamicsAPI.Core.DTOs.AnnouncementDTOs
{
    public class AnnouncementReadDto
    {
        public int AnnouncementId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime? ExpireAt { get; set; }
    }
}
