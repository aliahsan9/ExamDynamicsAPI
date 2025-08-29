namespace ExamDynamicsAPI.Core.DTOs.NotificationDTOs
{
    public class NotificationUpdateDto
    {
        public bool? IsRead { get; set; }  // Only allow updating the read status
    }
}
