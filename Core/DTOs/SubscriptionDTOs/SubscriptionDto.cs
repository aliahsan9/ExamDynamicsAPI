namespace ExamDynamicsAPI.Core.DTOs.SubscriptionDTOs
{
    public class SubscriptionDto
    {
        public int SubscriptionId { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int DurationInDays { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? UserId { get; set; }
    }
}
