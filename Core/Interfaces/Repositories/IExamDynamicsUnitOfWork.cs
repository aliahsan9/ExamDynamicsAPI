using System;
using System.Threading.Tasks;

namespace ExamDynamicsAPI.Core.Interfaces.Repositories
{
    public interface IExamDynamicsUnitOfWork : IDisposable
    {
        // ================= User / Profile =================
        IUserProfileRepository UserProfiles { get; }

        // ================= Exams & Content =================
        IExamRepository Exams { get; }
        ISubjectRepository Subjects { get; }
        ITopicRepository Topics { get; }
        IQuestionRepository Questions { get; }
        IOptionRepository Options { get; }
        IStudyMaterialRepository StudyMaterials { get; }
        IExamRegistrationRepository ExamRegistrations { get; }

        // ================= AI =================
        IAiSessionRepository AiSessions { get; } 
        IAiMessageRepository AiMessages { get; }

        // ================= Progress / Bookmarks =================
        IUserExamProgressRepository UserProgress { get; }
        IBookmarkRepository Bookmarks { get; }

        // ================= Announcements / Blog / FAQ / Contact / Feedback =================
        IAnnouncementRepository Announcements { get; }
        IBlogPostRepository BlogPosts { get; }
        IFaqRepository Faqs { get; }
        IContactMessageRepository ContactMessages { get; }
        IFeedbackRepository Feedbacks { get; }
        INotificationRepository Notifications { get; }

        // ================= Save Changes =================
        Task<int> CompleteAsync();
    }
}
