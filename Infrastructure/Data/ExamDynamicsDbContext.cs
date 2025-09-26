using ExamDynamicsAPI.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ExamDynamicsAPI.Infrastructure.Data
{
    // ✅ Use ApplicationUser & ApplicationRole (with int as key)
    public class ExamDynamicsDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, int>
    {
        public ExamDynamicsDbContext(DbContextOptions<ExamDynamicsDbContext> options)
            : base(options)
        {
        }

        // Core User Management
        public DbSet<UserProfile> UserProfiles { get; set; } = null!;
        public DbSet<UserProgress> UserProgress { get; set; } = null!;
         public DbSet<ContactMessage> ContactMessages { get; set; }


        // Exams & Subjects
        public DbSet<Exam> Exams { get; set; } = null!;
        public DbSet<Note> Notes { get; set; } = null!;
        public DbSet<Subject> Subjects { get; set; } = null!;
        public DbSet<Topic> Topics { get; set; } = null!;

        // Questions & Options
        public DbSet<Question> Questions { get; set; } = null!;
        public DbSet<Option> Options { get; set; } = null!;
        public DbSet<UserExamProgress> UserExamProgresses { get; set; } = null!;

        // Subscriptions
        public DbSet<Subscription> Subscriptions { get; set; } = null!;

        // Study Material
        public DbSet<StudyMaterial> StudyMaterials { get; set; } = null!;

        // Notifications, Materials, Results, Settings
        public DbSet<Notification> Notifications { get; set; } = null!;
        public DbSet<ExamMaterial> ExamMaterials { get; set; } = null!;
        public DbSet<ExamRegistration> ExamRegistrations { get; set; } = null!;
        public DbSet<Message> Messages { get; set; } = null!;
        public DbSet<Feedback> Feedbacks { get; set; } = null!;
        public DbSet<ExamResult> ExamResults { get; set; } = null!;
        public DbSet<Setting> Settings { get; set; } = null!;

        // Answers & Quizzes
        public DbSet<Answer> Answers { get; set; } = null!;
        public DbSet<Quiz> Quizzes { get; set; } = null!;
        public DbSet<Payment> Payments { get; set; } = null!;
        public DbSet<ForgotPassword> ForgotPasswords { get; set; } = null!;
        public DbSet<QuestionBank> QuestionBanks { get; set; } = null!;
        public DbSet<ExamCategory> ExamCategories { get; set; } = null!;

        // Progress & Bookmarks
        public DbSet<Bookmark> Bookmarks { get; set; } = null!;

        // Announcements & Blogs
        public DbSet<Announcement> Announcements { get; set; } = null!;
        public DbSet<BlogPost> BlogPosts { get; set; } = null!;

        // Support Section
        public DbSet<Faq> Faqs { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // 👇 IMPORTANT: Identity setup
            base.OnModelCreating(modelBuilder);

            // ===== User & Profile (1:1) =====
            modelBuilder.Entity<ApplicationUser>()
                .HasOne(u => u.Profile)
                .WithOne(p => p.User)
                .HasForeignKey<UserProfile>(p => p.UserId);

            // ===== Exam - Subject (1:Many) =====
            modelBuilder.Entity<Exam>()
                .HasMany(e => e.Subjects)
                .WithOne(s => s.Exam)
                .HasForeignKey(s => s.ExamId);

            // ===== Subject - Topic (1:Many) =====
            modelBuilder.Entity<Subject>()
                .HasMany(s => s.Topics)
                .WithOne(t => t.Subject)
                .HasForeignKey(t => t.SubjectId);

            // ===== Topic - Question (1:Many) =====
            modelBuilder.Entity<Topic>()
                .HasMany(t => t.Questions)
                .WithOne(q => q.Topic)
                .HasForeignKey(q => q.TopicId);

            // ===== Question - Option (1:Many) =====
            modelBuilder.Entity<Question>()
                .HasMany(q => q.Options)
                .WithOne(o => o.Question)
                .HasForeignKey(o => o.QuestionId);

            // ===== UserProgress (User - Topic) =====
            modelBuilder.Entity<UserProgress>()
                .HasOne(up => up.User)
                .WithMany(u => u.ProgressRecords)
                .HasForeignKey(up => up.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<UserProgress>()
                .HasOne(up => up.Topic)
                .WithMany()
                .HasForeignKey(up => up.TopicId)
                .OnDelete(DeleteBehavior.Restrict);

            // ===== Bookmark (User - Question) =====
            modelBuilder.Entity<Bookmark>()
                .HasOne(b => b.User)
                .WithMany(u => u.Bookmarks)
                .HasForeignKey(b => b.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Bookmark>()
                .HasOne(b => b.Question)
                .WithMany(q => q.Bookmarks)
                .HasForeignKey(b => b.QuestionId)
                .OnDelete(DeleteBehavior.Cascade);

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
            // ===== BlogPost - Author (User) =====
            modelBuilder.Entity<BlogPost>()
                .HasOne(b => b.Author)
                .WithMany(u => u.BlogPosts)
                .HasForeignKey(b => b.AuthorId);

            // ===== ExamRegistration - User & Exam =====
            modelBuilder.Entity<ExamRegistration>()
                .HasOne(er => er.ApplicationUser)
                .WithMany(u => u.ExamRegistrations)
                .HasForeignKey(er => er.UserId);

            modelBuilder.Entity<ExamRegistration>()
                .HasOne(er => er.Exam)
                .WithMany(e => e.ExamRegistrations)
                .HasForeignKey(er => er.ExamId);

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

            // ===== Subscription - Decimal precision =====
            modelBuilder.Entity<Subscription>()
                .Property(s => s.Price)
                .HasPrecision(18, 2);
        }
    }
}
