using AutoMapper;
using ExamDynamicsAPI.Core.DTOs.PaymentDTOs;
using ExamDynamicsAPI.Core.Interfaces.Repositories;
using ExamDynamicsAPI.Core.Interfaces.Services;
using ExamDynamicsAPI.Core.Models;

namespace ExamDynamicsAPI.Applications.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _repository;
        private readonly IMapper _mapper;

        public PaymentService(IPaymentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PaymentDto>> GetAllAsync()
        {
            var payments = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<PaymentDto>>(payments);
        }

        public async Task<PaymentDto?> GetByIdAsync(int id)
        {
            var payment = await _repository.GetByIdAsync(id);
            return payment == null ? null : _mapper.Map<PaymentDto>(payment);
        }

        public async Task<PaymentDto> CreateAsync(CreatePaymentDto createDto)
        {
            var payment = _mapper.Map<Payment>(createDto);
            await _repository.AddAsync(payment);
            return _mapper.Map<PaymentDto>(payment);
        }

        public async Task<bool> UpdateAsync(int id, UpdatePaymentDto updateDto)
        {
            var existingPayment = await _repository.GetByIdAsync(id);
            if (existingPayment == null)
                return false;

            _mapper.Map(updateDto, existingPayment);
            await _repository.UpdateAsync(existingPayment);
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existingPayment = await _repository.GetByIdAsync(id);
            if (existingPayment == null)
                return false;

            await _repository.DeleteAsync(id);
            return true;
        }

        public async Task<IEnumerable<PaymentDto>> GetByUserIdAsync(int userId)
        {
            var payments = await _repository.GetByUserIdAsync(userId);
            return _mapper.Map<IEnumerable<PaymentDto>>(payments);
        }

        public async Task<IEnumerable<PaymentDto>> GetSuccessfulPaymentsAsync()
        {
            var payments = await _repository.GetSuccessfulPaymentsAsync();
            return _mapper.Map<IEnumerable<PaymentDto>>(payments);
        }
    }
}
