using AutoMapper;
using ExamDynamicsAPI.Core.DTOs.ForgotPasswordDTOs;
using ExamDynamicsAPI.Core.Interfaces.Repositories;
using ExamDynamicsAPI.Core.Interfaces.Services;
using ExamDynamicsAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExamDynamicsAPI.Applications.Services
{
    public class ForgotPasswordService : IForgotPasswordService
    {
        private readonly IForgotPasswordRepository _repo;
        private readonly IMapper _mapper;

        public ForgotPasswordService(IForgotPasswordRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<ForgotPasswordDto> GenerateTokenAsync(ForgotPasswordCreateDto dto)
        {
            var token = Guid.NewGuid().ToString();

            var entity = new ForgotPassword
            {
                UserId = dto.UserId,
                Token = token,
                Expiration = DateTime.UtcNow.AddHours(1)
            };

            await _repo.AddAsync(entity);

            return _mapper.Map<ForgotPasswordDto>(entity);
        }

        public async Task<bool> ResetPasswordAsync(ForgotPasswordResetDto dto)
        {
            var entity = await _repo.GetByTokenAsync(dto.Token);
            if (entity == null || entity.IsUsed || entity.Expiration < DateTime.UtcNow)
                return false;

            // TODO: Update the user's password here using your UserRepository
            // Example: await _userRepo.UpdatePasswordAsync(entity.UserId, dto.NewPassword);

            entity.IsUsed = true;
            await _repo.UpdateAsync(entity);
            return true;
        }

        public async Task<IEnumerable<ForgotPasswordDto>> GetByUserIdAsync(int userId)
        {
            var records = await _repo.GetByUserIdAsync(userId);
            return _mapper.Map<IEnumerable<ForgotPasswordDto>>(records);
        }
    }
}
