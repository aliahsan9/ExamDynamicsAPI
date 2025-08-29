using AutoMapper;
using ExamDynamicsAPI.Core.DTOs.StudyMaterialDTOs;
using ExamDynamicsAPI.Core.Interfaces.Repositories;
using ExamDynamicsAPI.Core.Interfaces.Services;
using ExamDynamicsAPI.Core.Models;

namespace ExamDynamicsAPI.Applications.Services
{
    public class StudyMaterialService : IStudyMaterialService
    {
        private readonly IStudyMaterialRepository _repository;
        private readonly IMapper _mapper;

        public StudyMaterialService(IStudyMaterialRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<StudyMaterialDto>> GetAllAsync()
        {
            var materials = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<StudyMaterialDto>>(materials);
        }

        public async Task<StudyMaterialDto?> GetByIdAsync(int id)
        {
            var material = await _repository.GetByIdAsync(id);
            return material == null ? null : _mapper.Map<StudyMaterialDto>(material);
        }

        public async Task<StudyMaterialDto> CreateAsync(CreateStudyMaterialDto createDto)
        {
            var material = _mapper.Map<StudyMaterial>(createDto);
            await _repository.AddAsync(material);
            return _mapper.Map<StudyMaterialDto>(material);
        }

        public async Task<StudyMaterialDto?> UpdateAsync(int id, UpdateStudyMaterialDto updateDto)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null) return null;

            _mapper.Map(updateDto, existing);
            await _repository.UpdateAsync(existing);
            return _mapper.Map<StudyMaterialDto>(existing);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null) return false;

            await _repository.DeleteAsync(id);
            return true;
        }
    }
}
