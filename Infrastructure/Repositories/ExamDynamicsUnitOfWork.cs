using ExamDynamicsAPI.Core.Interfaces.Repositories;
using ExamDynamicsAPI.Infrastructure.Data;

namespace ExamDynamicsAPI.Infrastructure.Repositories
{
    public class ExamDynamicsUnitOfWork : IExamDynamicsUnitOfWork
    {
        private readonly ExamDynamicsDbContext _context;

        // ================= Repositories =================
        public IExamRepository Exams { get; }
        public IBlogPostRepository BlogPosts { get; }
        public IQuestionRepository Questions { get; }
        public IOptionRepository Options { get; }

        public ExamDynamicsUnitOfWork(
            ExamDynamicsDbContext context,
            IExamRepository exams,
            IBlogPostRepository blogPosts,
            IQuestionRepository questions,
            IOptionRepository options
        )
        {
            _context = context;

            Exams = exams;
            BlogPosts = blogPosts;
            Questions = questions;
            Options = options;
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
