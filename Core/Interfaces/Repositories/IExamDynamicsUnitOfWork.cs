namespace ExamDynamicsAPI.Core.Interfaces.Repositories
{
    public interface IExamDynamicsUnitOfWork : IDisposable
    {

        // ================= Exams & Content =================
        IExamRepository Exams { get; }
        IQuestionRepository Questions { get; }
        IOptionRepository Options { get; }
     
        IBlogPostRepository BlogPosts { get; }

        // ================= Save Changes =================
        Task<int> CompleteAsync();
    }
}
