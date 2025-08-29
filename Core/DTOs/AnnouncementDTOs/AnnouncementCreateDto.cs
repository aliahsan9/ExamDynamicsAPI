using System.ComponentModel.DataAnnotations;

namespace ExamDynamicsAPI.Core.DTOs.AnnouncementDTOs
{
    public class AnnouncementCreateDto
    {
        [Required, MaxLength(200)]
        public string Title { get; set; } = string.Empty;

        [Required, MaxLength(2000)]
        public string Description { get; set; } = string.Empty;

        public DateTime? ExpireAt { get; set; }
    }
}
