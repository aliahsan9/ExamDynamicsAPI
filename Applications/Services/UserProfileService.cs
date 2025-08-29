using AutoMapper;
using ExamDynamicsAPI.Core.DTOs.UserProfileDTOs;
using ExamDynamicsAPI.Core.Interfaces.Repositories;
using ExamDynamicsAPI.Core.Interfaces.Services;
using ExamDynamicsAPI.Core.Models;

namespace ExamDynamicsAPI.Applications.Services
{
    public class UserProfileService : IUserProfileService
    {
        private readonly IUserProfileRepository _repository;
        private readonly IMapper _mapper;

        public UserProfileService(IUserProfileRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserProfileDto>> GetAllAsync()
        {
            var profiles = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<UserProfileDto>>(profiles);
        }

        public async Task<UserProfileDto?> GetByIdAsync(int id)
        {
            var profile = await _repository.GetByIdAsync(id);
            return profile == null ? null : _mapper.Map<UserProfileDto>(profile);
        }

        public async Task<UserProfileDto> CreateAsync(UserProfileCreateDto createDto)
        {
            var profile = _mapper.Map<UserProfile>(createDto);
            await _repository.AddAsync(profile); // ✅ just await, no assignment
            return _mapper.Map<UserProfileDto>(profile); // map the same entity
        }

        public async Task<bool> UpdateAsync(int id, UserProfileUpdateDto updateDto)
        {
            var profile = _mapper.Map<UserProfile>(updateDto);
            profile.Id = id;
            await _repository.UpdateAsync(profile); // ✅ just await, no assignment
            return true; // return true after successful update
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return false;

            await _repository.DeleteAsync(id);
            return true;
        }

        public async Task<UserProfileDto?> GetByEmailAsync(string email)
        {
            var profile = await _repository.GetByEmailAsync(email);
            return profile == null ? null : _mapper.Map<UserProfileDto>(profile);
        }
    }
}
