using System.ComponentModel.DataAnnotations;

namespace ExamDynamicsAPI.Core.DTOs.NotificationDTOs
{
    public class NotificationCreateDto
    {
        [Required]
        [MaxLength(500)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [MaxLength(2000)]
        public string Message { get; set; } = string.Empty;

        public int UserId { get; set; }  // The user who will receive the notification

        [MaxLength(50)]
        public string Type { get; set; } = "Info";

        public int? ReferenceId { get; set; }
        [MaxLength(100)]
        public string? ReferenceType { get; set; }
    }
}
