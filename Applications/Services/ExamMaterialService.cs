using AutoMapper;
using ExamDynamicsAPI.Core.DTOs;
using ExamDynamicsAPI.Core.DTOs.ExamMaterialDTOs;
using ExamDynamicsAPI.Core.Interfaces.Repositories;
using ExamDynamicsAPI.Core.Interfaces.Services;
using ExamDynamicsAPI.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExamDynamicsAPI.Applications.Services
{
    public class ExamMaterialService : IExamMaterialService
    {
        private readonly IExamMaterialRepository _repository;
        private readonly IMapper _mapper;

        public ExamMaterialService(IExamMaterialRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ExamMaterialReadDto>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<ExamMaterialReadDto>>(entities);
        }

        public async Task<ExamMaterialReadDto?> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return entity == null ? null : _mapper.Map<ExamMaterialReadDto>(entity);
        }

        public async Task<ExamMaterialReadDto> CreateAsync(ExamMaterialCreateDto dto)
        {
            var entity = _mapper.Map<ExamMaterial>(dto);
            await _repository.AddAsync(entity);
            return _mapper.Map<ExamMaterialReadDto>(entity);
        }

        public async Task UpdateAsync(int id, ExamMaterialUpdateDto dto)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) throw new KeyNotFoundException($"ExamMaterial with Id={id} not found.");
            _mapper.Map(dto, entity);
            await _repository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
