namespace ExamDynamicsAPI.Core.Interfaces.Repositories
{
    public interface IExamDynamicsUnitOfWork : IDisposable
    {

<<<<<<< HEAD
=======
        // ================= Exams & Content =================
>>>>>>> 0b8b2b3dbb9259d21d302a46bf22d08f59f80a63
        IExamRepository Exams { get; }
        IQuestionRepository Questions { get; }
        IOptionRepository Options { get; }
     
<<<<<<< HEAD
=======
        // ================= Save Changes =================
>>>>>>> 0b8b2b3dbb9259d21d302a46bf22d08f59f80a63
        Task<int> CompleteAsync();
    }
}
