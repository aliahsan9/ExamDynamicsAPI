using ExamDynamicsAPI.Core.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ExamDynamicsAPI.Infrastructure.Data
{

    public class ExamDynamicsDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, int>
    {
        public ExamDynamicsDbContext(DbContextOptions<ExamDynamicsDbContext> options)
            : base(options)
        {
        }

         public DbSet<ContactMessage> ContactMessages { get; set; }


        // Exams & Subjects
        public DbSet<Exam> Exams { get; set; } = null!;

        // Questions & Options
        public DbSet<Question> Questions { get; set; } = null!;
        public DbSet<Option> Options { get; set; } = null!;
        public DbSet<Message> Messages { get; set; } = null!;
        // Answers & Quizzes
        public DbSet<Answer> Answers { get; set; } = null!;
        public DbSet<ExamCategory> ExamCategories { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // 👇 IMPORTANT: Identity setup
            base.OnModelCreating(modelBuilder);

                // ===== Question - Option (1:Many) =====
            modelBuilder.Entity<Question>()
                .HasMany(q => q.Options)
                .WithOne(o => o.Question)
                .HasForeignKey(o => o.QuestionId);
                
            // ===== Messages (avoid multiple cascade paths) =====
            modelBuilder.Entity<Message>()
                .HasOne(m => m.Sender)
                .WithMany()
                .HasForeignKey(m => m.SenderId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Message>()
                .HasOne(m => m.Receiver)
                .WithMany()
                .HasForeignKey(m => m.ReceiverId)
                .OnDelete(DeleteBehavior.Restrict);
       

            // ===== Answer - User & Question =====
            modelBuilder.Entity<Answer>()
                .HasOne(a => a.User)
                .WithMany(u => u.Answers)
                .HasForeignKey(a => a.UserId);

            modelBuilder.Entity<Answer>()
                .HasOne(a => a.Question)
                .WithMany(q => q.Answers)
                .HasForeignKey(a => a.QuestionId);

            // ===== Option - Answer (1:Many) =====
            modelBuilder.Entity<Option>()
                .HasMany(o => o.Answers)
                .WithOne(a => a.Option)
                .HasForeignKey(a => a.OptionId);
        }
    }
}
