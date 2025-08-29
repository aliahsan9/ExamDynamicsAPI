using AutoMapper;
using ExamDynamicsAPI.Core.DTOs.SubscriptionDTOs;
using ExamDynamicsAPI.Core.Interfaces.Repositories;
using ExamDynamicsAPI.Core.Interfaces.Services;
using ExamDynamicsAPI.Core.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamDynamicsAPI.Applications.Services
{
    public class SubscriptionService : ISubscriptionService
    {
        private readonly ISubscriptionRepository _repository;
        private readonly IMapper _mapper;

        public SubscriptionService(ISubscriptionRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SubscriptionDto>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<SubscriptionDto>>(entities);
        }

        public async Task<SubscriptionDto?> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return entity == null ? null : _mapper.Map<SubscriptionDto>(entity);
        }

        public async Task<SubscriptionDto> CreateAsync(SubscriptionCreateDto createDto)
        {
            var entity = _mapper.Map<Subscription>(createDto);
            await _repository.AddAsync(entity);
            return _mapper.Map<SubscriptionDto>(entity);
        }

        public async Task<bool> UpdateAsync(int id, SubscriptionUpdateDto updateDto)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return false;

            _mapper.Map(updateDto, entity);
            await _repository.UpdateAsync(entity);
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return false;

            await _repository.DeleteAsync(id);
            return true;
        }

        public async Task<IEnumerable<SubscriptionDto>> GetByUserIdAsync(int userId)
        {
            var entities = await _repository.GetByUserIdAsync(userId);
            return _mapper.Map<IEnumerable<SubscriptionDto>>(entities);
        }
    }
}
