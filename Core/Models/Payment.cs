using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static ExamDynamicsAPI.Core.Models.Answer;

namespace ExamDynamicsAPI.Core.Models
{
    public class Payment
    {
        [Key]
        public int PaymentId { get; set; }

        [Required]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser? User { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }

        [Required]
        [MaxLength(20)]
        public string Status { get; set; } = string.Empty; // e.g., "Successful", "Failed", "Pending"

        [Required]
        [MaxLength(50)]
        public string PaymentMethod { get; set; } = string.Empty; // e.g., "Credit Card", "PayPal"

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
