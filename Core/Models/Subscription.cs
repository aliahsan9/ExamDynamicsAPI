using System;
using System.ComponentModel.DataAnnotations;

namespace ExamDynamicsAPI.Core.Models
{
    public class Subscription
    {
        [Key]
        public int SubscriptionId { get; set; }

        [Required, MaxLength(150)]
        public string Name { get; set; } = string.Empty;

        [Required]
        public decimal Price { get; set; } 

        [Required]
        public int DurationInDays { get; set; } // subscription period

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Relations
        public int? UserId { get; set; } // if subscription belongs to a user
    }
}
