using AutoMapper;
using ExamDynamicsAPI.Core.DTOs.ExamDTOs;
using ExamDynamicsAPI.Core.Interfaces.Repositories;
using ExamDynamicsAPI.Core.Interfaces.Services;
using ExamDynamicsAPI.Core.Models;

namespace ExamDynamicsAPI.Applications.Services
{
    public class ExamService : IExamService
    {
        private readonly IExamRepository _repository;
        private readonly IMapper _mapper;

        public ExamService(IExamRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ExamDto>> GetAllAsync()
        {
            var exams = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<ExamDto>>(exams);
        }

        public async Task<ExamDto?> GetByIdAsync(int id)
        {
            var exam = await _repository.GetByIdAsync(id);
            return exam == null ? null : _mapper.Map<ExamDto>(exam);
        }

        public async Task<ExamDto> CreateAsync(CreateExamDto createDto)
        {
            var exam = _mapper.Map<Exam>(createDto);
            await _repository.AddAsync(exam);
            return _mapper.Map<ExamDto>(exam);
        }
 
        public async Task<bool> UpdateAsync(int id, UpdateExamDto updateDto)
        {
            var exam = await _repository.GetByIdAsync(id);
            if (exam == null) return false;

            _mapper.Map(updateDto, exam);
            await _repository.UpdateAsync(exam);
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var exam = await _repository.GetByIdAsync(id);
            if (exam == null) return false;

            await _repository.DeleteAsync(id);
            return true;
        }

        public async Task<IEnumerable<ExamDto>> GetBySubjectIdAsync(int subjectId)
        {
            var exams = await _repository.GetBySubjectIdAsync(subjectId);
            return _mapper.Map<IEnumerable<ExamDto>>(exams);
        }
    }
}
