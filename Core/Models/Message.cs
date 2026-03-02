using System.ComponentModel.DataAnnotations;

namespace ExamDynamicsAPI.Core.Models
{
   public class Message
{
    [Key]
    public int Id { get; set; }

    [Required, MaxLength(2000)]
    public string Content { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public int SenderId { get; set; }
    public ApplicationUser Sender { get; set; } = null!;

    public int ReceiverId { get; set; }
    public ApplicationUser Receiver { get; set; } = null!;

    public bool IsRead { get; set; } = false;
}

}
