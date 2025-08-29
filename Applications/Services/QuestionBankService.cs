using AutoMapper;
using ExamDynamicsAPI.Core.DTOs;
using ExamDynamicsAPI.Core.DTOs.QuestionBankDTOs;
using ExamDynamicsAPI.Core.Interfaces.Repositories;
using ExamDynamicsAPI.Core.Interfaces.Services;
using ExamDynamicsAPI.Core.Models;

namespace ExamDynamicsAPI.Applications.Services
{
    public class QuestionBankService : IQuestionBankService
    {
        private readonly IQuestionBankRepository _repository;
        private readonly IMapper _mapper;

        public QuestionBankService(IQuestionBankRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<QuestionBankDto>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<QuestionBankDto>>(entities);
        }

        public async Task<QuestionBankDto?> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return _mapper.Map<QuestionBankDto>(entity);
        }

        public async Task<QuestionBankDto> CreateAsync(QuestionBankCreateDto dto)
        {
            var entity = _mapper.Map<QuestionBank>(dto);
            await _repository.AddAsync(entity);
            return _mapper.Map<QuestionBankDto>(entity);
        }

        public async Task UpdateAsync(QuestionBankUpdateDto dto)
        {
            var entity = _mapper.Map<QuestionBank>(dto);
            await _repository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<QuestionBankDto>> GetByTitleAsync(string title)
        {
            var entities = await _repository.GetByTitleAsync(title);
            return _mapper.Map<IEnumerable<QuestionBankDto>>(entities);
        }
    }
}
