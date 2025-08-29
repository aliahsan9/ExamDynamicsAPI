using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static ExamDynamicsAPI.Core.Models.Answer;

namespace ExamDynamicsAPI.Core.Models
{
    public class Profile 
    {
        [Key, ForeignKey("User")]
        public int UserId { get; set; }   // same as UserId (1-to-1)

        [MaxLength(50)]
        public string Country { get; set; } = string.Empty;

        [MaxLength(50)]
        public string City { get; set; } = string.Empty;

        [MaxLength(100)]
        public string Email { get; set; } = string.Empty;  // Added Email

        public string Bio { get; set; } = string.Empty;
        public string ProfileImageUrl { get; set; } = string.Empty;

        public ApplicationUser? User { get; set; }
    }
}
