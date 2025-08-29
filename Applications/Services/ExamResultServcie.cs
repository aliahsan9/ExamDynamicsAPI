using AutoMapper;
using ExamDynamicsAPI.Core.DTOs.ExamResultDTOs;
using ExamDynamicsAPI.Core.Interfaces.Repositories;
using ExamDynamicsAPI.Core.Interfaces.Services;
using ExamDynamicsAPI.Core.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks; 
 
namespace ExamDynamicsAPI.Applications.Services
{
    public class ExamResultService : IExamResultService
    {
        private readonly IGenericRepository<ExamResult> _repository;
        private readonly IMapper _mapper;

        // Constructor injection guarantees initialization
        public ExamResultService(IGenericRepository<ExamResult> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // ================= GET ALL =================
        public async Task<IEnumerable<ExamResultDto>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<ExamResultDto>>(entities);
        }

        // ================= GET BY ID =================
        public async Task<ExamResultDto?> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return entity == null ? null : _mapper.Map<ExamResultDto>(entity);
        }

        // ================= GET BY USER =================
        public async Task<IEnumerable<ExamResultDto>> GetByUserIdAsync(int userId)
        {
            var all = await _repository.GetAllAsync();
            var filtered = all.Where(r => r.UserId == userId);
            return _mapper.Map<IEnumerable<ExamResultDto>>(filtered);
        }

        // ================= GET BY EXAM =================
        public async Task<IEnumerable<ExamResultDto>> GetByExamIdAsync(int examId)
        {
            var all = await _repository.GetAllAsync();
            var filtered = all.Where(r => r.ExamId == examId);
            return _mapper.Map<IEnumerable<ExamResultDto>>(filtered);
        }

        // ================= CREATE =================
        public async Task<ExamResultDto> CreateAsync(ExamResultCreateDto createDto)
        {
            var entity = _mapper.Map<ExamResult>(createDto);
            await _repository.AddAsync(entity);
            return _mapper.Map<ExamResultDto>(entity);
        }

        // ================= UPDATE =================
        public async Task<bool> UpdateAsync(int id, ExamResultUpdateDto updateDto)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return false;

            _mapper.Map(updateDto, entity);
            await _repository.UpdateAsync(entity);
            return true;
        }

        // ================= DELETE =================
        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return false;

            await _repository.DeleteAsync(entity.Id);
            return true;
        }
    }
}