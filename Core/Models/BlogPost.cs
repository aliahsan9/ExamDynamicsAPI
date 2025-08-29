using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExamDynamicsAPI.Core.Models
{
    public class BlogPost
    {
        [Key]
        public int BlogPostId { get; set; }

        [Required, MaxLength(200)]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Content { get; set; } = string.Empty;

        // Foreign key to Identity User
        [ForeignKey(nameof(Author))]
        public int AuthorId { get; set; }

        public ApplicationUser Author { get; set; } = null!;

        public DateTime PublishedAt { get; set; } = DateTime.UtcNow;

        public bool IsPublished { get; set; } = true;
    }
}
