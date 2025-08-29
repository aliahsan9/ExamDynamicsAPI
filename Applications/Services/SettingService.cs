using AutoMapper;
using ExamDynamicsAPI.Core.DTOs;
using ExamDynamicsAPI.Core.DTOs.settingDTOs;
using ExamDynamicsAPI.Core.Interfaces.Repositories;
using ExamDynamicsAPI.Core.Interfaces.Services;
using ExamDynamicsAPI.Core.Models;

namespace ExamDynamicsAPI.Applications.Services
{
    public class SettingService : ISettingService
    {
        private readonly ISettingRepository _repository;
        private readonly IMapper _mapper;

        public SettingService(ISettingRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SettingDto>> GetAllAsync()
        {
            var settings = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<SettingDto>>(settings);
        }

        public async Task<SettingDto?> GetByIdAsync(int id)
        {
            var setting = await _repository.GetByIdAsync(id);
            return _mapper.Map<SettingDto?>(setting);
        }

        public async Task<SettingDto> CreateAsync(CreateSettingDto dto)
        {
            var entity = _mapper.Map<Setting>(dto);
            await _repository.AddAsync(entity);
            return _mapper.Map<SettingDto>(entity);
        }
 
        public async Task<SettingDto?> UpdateAsync(UpdateSettingDto dto)
        {
            var entity = await _repository.GetByIdAsync(dto.SettingId);
            if (entity == null) return null;

            _mapper.Map(dto, entity);
            await _repository.UpdateAsync(entity);

            return _mapper.Map<SettingDto>(entity);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return false;

            await _repository.DeleteAsync(id);
            return true;
        }
    }
}
