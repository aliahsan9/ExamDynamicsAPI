namespace ExamDynamicsAPI.Core.Interfaces.Repositories
{
    public interface IExamDynamicsUnitOfWork : IDisposable
    {

        IExamRepository Exams { get; }
        IQuestionRepository Questions { get; }
        IOptionRepository Options { get; }
     
        Task<int> CompleteAsync();
    }
}
