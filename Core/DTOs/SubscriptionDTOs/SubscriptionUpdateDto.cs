namespace ExamDynamicsAPI.Core.DTOs.SubscriptionDTOs
{
    public class SubscriptionUpdateDto
    {
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int DurationInDays { get; set; }
        public int? UserId { get; set; }
    }
}
