namespace ExamDynamicsAPI.Core.DTOs.PaymentDTOs
{
    public class CreatePaymentDto
    {
        public int UserId { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; } = string.Empty;
    }
}
