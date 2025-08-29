using System;

namespace ExamDynamicsAPI.Core.DTOs.NotificationDTOs
{
    public class NotificationReadDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public bool IsRead { get; set; }
        public DateTime CreatedAt { get; set; }

        public int UserId { get; set; }
        public string? UserName { get; set; }  // Optional: name from User entity

        public string Type { get; set; } = "Info";
        public int? ReferenceId { get; set; }
        public string? ReferenceType { get; set; }
    }
}
