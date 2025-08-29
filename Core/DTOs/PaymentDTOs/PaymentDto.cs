namespace ExamDynamicsAPI.Core.DTOs.PaymentDTOs
{
    public class PaymentDto
    {
        public int PaymentId { get; set; }
        public int UserId { get; set; }
        public decimal Amount { get; set; }
        public string Status { get; set; } = string.Empty;
        public string PaymentMethod { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
    }
}
