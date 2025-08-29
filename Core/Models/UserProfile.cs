using static ExamDynamicsAPI.Core.Models.Answer;
using static ExamDynamicsAPI.Core.Models.BlogPost;

namespace ExamDynamicsAPI.Core.Models
{
    public class UserProfile
    {
        public int Id { get; set; } 
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Bio { get; set; } = string.Empty;
        public string? ProfilePictureUrl { get; set; }

        public int UserId { get; set; }
        public ApplicationUser User { get; set; } = null!;
        public ICollection<ApplicationUser>? Users { get; set; }
    }
} 
 