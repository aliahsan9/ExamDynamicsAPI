using ExamDynamicsAPI.Core.Interfaces.Repositories;
using ExamDynamicsAPI.Core.Interfaces.Services;
using ExamDynamicsAPI.Core.Models;

namespace ExamDynamicsAPI.Applications.Services
{
    public class SubjectService : ISubjectService
    {
        private readonly ISubjectRepository _subjectRepository;

        public SubjectService(ISubjectRepository subjectRepository)
        {
            _subjectRepository = subjectRepository;
        }

        public async Task<IEnumerable<Subject>> GetAllSubjectsAsync()
        {
            return await _subjectRepository.GetAllAsync();
        }

        public async Task<Subject?> GetSubjectByIdAsync(int id)
        {
            return await _subjectRepository.GetByIdAsync(id);
        }

        public async Task AddSubjectAsync(Subject subject)
        {
            await _subjectRepository.AddAsync(subject);
        }

        public async Task UpdateSubjectAsync(Subject subject)
        {
            await _subjectRepository.UpdateAsync(subject);
        }

        public async Task DeleteSubjectAsync(int id)
        {
            await _subjectRepository.DeleteAsync(id);
        }
    }
}