using AutoMapper;
using ExamDynamicsAPI.Core.DTOs;
using ExamDynamicsAPI.Core.DTOs.AnnouncementDTOs;
using ExamDynamicsAPI.Core.Interfaces.Repositories;
using ExamDynamicsAPI.Core.Interfaces.Services;
using ExamDynamicsAPI.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExamDynamicsAPI.Applications.Services
{
    public class AnnouncementService : IAnnouncementService
    {
        private readonly IExamDynamicsUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AnnouncementService(IExamDynamicsUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AnnouncementReadDto>> GetAllAsync()
        {
            var announcements = await _unitOfWork.Announcements.GetAllAsync();
            return _mapper.Map<IEnumerable<AnnouncementReadDto>>(announcements);
        }

        public async Task<AnnouncementReadDto?> GetByIdAsync(int id)
        {
            var announcement = await _unitOfWork.Announcements.GetByIdAsync(id);
            return _mapper.Map<AnnouncementReadDto>(announcement);
        }

        public async Task<AnnouncementReadDto> CreateAsync(AnnouncementCreateDto dto)
        {
            var announcement = _mapper.Map<Announcement>(dto);
            await _unitOfWork.Announcements.AddAsync(announcement);
            await _unitOfWork.CompleteAsync();
            return _mapper.Map<AnnouncementReadDto>(announcement);
        }

        public async Task<bool> UpdateAsync(int id, AnnouncementUpdateDto dto)
        {
            var announcement = await _unitOfWork.Announcements.GetByIdAsync(id);
            if (announcement == null) return false;

            _mapper.Map(dto, announcement);
            _unitOfWork.Announcements.Update(announcement);
            await _unitOfWork.CompleteAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var announcement = await _unitOfWork.Announcements.GetByIdAsync(id);
            if (announcement == null) return false;

            _unitOfWork.Announcements.Delete(announcement);
            await _unitOfWork.CompleteAsync();
            return true;
        }
    }
}
