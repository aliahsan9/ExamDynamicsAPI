using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace ExamDynamicsAPI.Core.Models
{
    public class ApplicationUser : IdentityUser<int>
    {
        public string FullName { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public virtual UserProfile? Profile { get; set; }
        public virtual ICollection<UserProgress> ProgressRecords { get; set; } = new HashSet<UserProgress>();
        public virtual ICollection<Bookmark> Bookmarks { get; set; } = new HashSet<Bookmark>();
        public virtual ICollection<BlogPost> BlogPosts { get; set; } = new HashSet<BlogPost>();
        public virtual ICollection<Note> Notes { get; set; } = new HashSet<Note>();
        public virtual ICollection<Answer> Answers { get; set; } = new HashSet<Answer>();
        public virtual ICollection<ExamRegistration> ExamRegistrations { get; set; } = new HashSet<ExamRegistration>();
    }

    public class ApplicationRole : IdentityRole<int>
    {
        public string Description { get; set; } = string.Empty;
        public virtual ICollection<IdentityUserRole<int>> UserRoles { get; set; } = new HashSet<IdentityUserRole<int>>();
    }
}
