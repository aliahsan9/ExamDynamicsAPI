using AutoMapper;
using ExamDynamicsAPI.Core.DTOs.ExamRegistrationDTOs;
using ExamDynamicsAPI.Core.Interfaces.Repositories;
using ExamDynamicsAPI.Core.Interfaces.Services;
using ExamDynamicsAPI.Core.Models;

namespace ExamDynamicsAPI.Applications.Services
{
    public class ExamRegistrationService : IExamRegistrationService
    {
        private readonly IExamRegistrationRepository _repository;
        private readonly IMapper _mapper;

        public ExamRegistrationService(IExamRegistrationRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ExamRegistrationDto>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<ExamRegistrationDto>>(entities);
        }

        public async Task<ExamRegistrationDto?> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return _mapper.Map<ExamRegistrationDto?>(entity);
        }

        public async Task<ExamRegistrationDto> RegisterAsync(ExamRegistrationCreateDto dto)
        {
            var entity = _mapper.Map<ExamRegistration>(dto);
            await _repository.AddAsync(entity);
            return _mapper.Map<ExamRegistrationDto>(entity);
        }

        public async Task<bool> UpdateAsync(int id, ExamRegistrationUpdateDto dto)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return false;

            _mapper.Map(dto, entity);
            await _repository.UpdateAsync(entity);
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return false;

            await _repository.DeleteAsync(entity);
            return true;
        }

        public async Task<IEnumerable<ExamRegistrationDto>> GetByUserIdAsync(int userId)
        {
            var entities = await _repository.GetByUserIdAsync(userId);
            return _mapper.Map<IEnumerable<ExamRegistrationDto>>(entities);
        }

        public async Task<IEnumerable<ExamRegistrationDto>> GetByExamIdAsync(int examId)
        {
            var entities = await _repository.GetByExamIdAsync(examId);
            return _mapper.Map<IEnumerable<ExamRegistrationDto>>(entities);
        }
    }
}
