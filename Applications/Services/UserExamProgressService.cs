using AutoMapper;
using ExamDynamicsAPI.Core.DTOs.UserExamProgressDTOs;
using ExamDynamicsAPI.Core.Interfaces.Repositories;
using ExamDynamicsAPI.Core.Interfaces.Services;
using ExamDynamicsAPI.Core.Models;

namespace ExamDynamicsAPI.Applications.Services
{
    public class UserExamProgressService : IUserExamProgressService
    {
        private readonly IUserExamProgressRepository _repository;
        private readonly IMapper _mapper;

        // Single constructor to initialize dependencies
        public UserExamProgressService(IUserExamProgressRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // Get all UserExamProgress records
        public async Task<IEnumerable<UserExamProgressReadDto>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<UserExamProgressReadDto>>(entities);
        }

        // Get UserExamProgress by Id
        public async Task<UserExamProgressReadDto?> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return entity == null ? null : _mapper.Map<UserExamProgressReadDto>(entity);
        }

        // Get UserExamProgress by UserId
        public async Task<IEnumerable<UserExamProgressReadDto>> GetByUserIdAsync(int userId)
        {
            var entities = await _repository.GetByUserIdAsync(userId);
            return _mapper.Map<IEnumerable<UserExamProgressReadDto>>(entities);
        }

        // Get UserExamProgress by ExamId
        public async Task<IEnumerable<UserExamProgressReadDto>> GetByExamIdAsync(int examId)
        {
            var entities = await _repository.GetByExamIdAsync(examId);
            return _mapper.Map<IEnumerable<UserExamProgressReadDto>>(entities);
        }

        // Create a new UserExamProgress record
        public async Task<UserExamProgressReadDto> CreateAsync(UserExamProgressCreateDto createDto)
        {
            var entity = _mapper.Map<UserExamProgress>(createDto);
            await _repository.AddAsync(entity);
            return _mapper.Map<UserExamProgressReadDto>(entity);
        }
     
        // Update an existing UserExamProgress record
        public async Task<bool> UpdateAsync(int id, UserExamProgressUpdateDto updateDto)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return false;

            _mapper.Map(updateDto, entity);
            await _repository.UpdateAsync(entity);
            return true;
        }

        // Delete a UserExamProgress record
        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return false;

            await _repository.DeleteAsync(id);
            return true;
        }
    }
}
