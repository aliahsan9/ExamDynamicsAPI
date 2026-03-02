using Microsoft.AspNetCore.Identity;

namespace ExamDynamicsAPI.Core.Models
{
    public class ApplicationUser : IdentityUser<int>
    {
        public string FullName { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public virtual ICollection<BlogPost> BlogPosts { get; set; } = new HashSet<BlogPost>();
        public virtual ICollection<Answer> Answers { get; set; } = new HashSet<Answer>();
    }

    public class ApplicationRole : IdentityRole<int>
    {
        public string Description { get; set; } = string.Empty;
        public virtual ICollection<IdentityUserRole<int>> UserRoles { get; set; } = new HashSet<IdentityUserRole<int>>();
    }
}
