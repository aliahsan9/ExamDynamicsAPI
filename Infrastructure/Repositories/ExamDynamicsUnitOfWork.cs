using ExamDynamicsAPI.Core.Interfaces;
using ExamDynamicsAPI.Core.Interfaces.Repositories;
using ExamDynamicsAPI.Infrastructure.Data;

namespace ExamDynamicsAPI.Infrastructure.Repositories
{
    public class ExamDynamicsUnitOfWork : IExamDynamicsUnitOfWork
    {
        private readonly ExamDynamicsDbContext _context;

        // ================= Repositories =================
        public IUserProfileRepository UserProfiles { get; }
        public IExamRepository Exams { get; }
        public IBlogPostRepository BlogPosts { get; }
        public IExamRegistrationRepository ExamRegistrations { get; }
        public IFeedbackRepository Feedbacks { get; }
        public INotificationRepository Notifications { get; }
        public ISubjectRepository Subjects { get; } 
        public ITopicRepository Topics { get; }
        public IQuestionRepository Questions { get; }
        public IOptionRepository Options { get; }
        public IStudyMaterialRepository StudyMaterials { get; }
        public IAiSessionRepository AiSessions { get; }
        public IAiMessageRepository AiMessages { get; }
        public IBookmarkRepository Bookmarks { get; }
        public IUserExamProgressRepository UserProgress { get; }
        public IAnnouncementRepository Announcements { get; }
        public IFaqRepository Faqs { get; }

        public ExamDynamicsUnitOfWork(
            ExamDynamicsDbContext context,
            IUserProfileRepository userProfiles,
            IExamRepository exams,
            IBlogPostRepository blogPosts,
            IExamRegistrationRepository examRegistrations,
            IFeedbackRepository feedbacks,
            INotificationRepository notifications,
            ISubjectRepository subjects,
            ITopicRepository topics,
            IQuestionRepository questions,
            IOptionRepository options,
            IStudyMaterialRepository studyMaterials,
            IAiSessionRepository aiSessions,
            IAiMessageRepository aiMessages,
            IBookmarkRepository bookmarks,
            IUserExamProgressRepository userProgress,
            IAnnouncementRepository announcements,
            IFaqRepository faqs
        )
        {
            _context = context;

            UserProfiles = userProfiles;
            Exams = exams;
            BlogPosts = blogPosts;
            ExamRegistrations = examRegistrations;
            Feedbacks = feedbacks;
            Notifications = notifications;
            Subjects = subjects;
            Topics = topics;
            Questions = questions;
            Options = options;
            StudyMaterials = studyMaterials;
            AiSessions = aiSessions;
            AiMessages = aiMessages;
            Bookmarks = bookmarks;
            UserProgress = userProgress;
            Announcements = announcements;
            Faqs = faqs;
        }

        // ================= Save Changes =================
        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        // ================= Dispose =================
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
