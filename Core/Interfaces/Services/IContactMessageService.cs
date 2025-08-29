using ExamDynamicsAPI.Core.DTOs.ContactMessageDTOs;

namespace ExamDynamicsAPI.Core.Interfaces.Services

{
    public interface IContactMessageService
    {
        Task<IEnumerable<ContactMessageDto>> GetAllAsync();
        Task<ContactMessageDto?> GetByIdAsync(int id);
        Task<ContactMessageDto> AddAsync(CreateContactMessageDto createDto);
        Task<ContactMessageDto?> UpdateAsync(int id, UpdateContactMessageDto updateDto);
        Task<bool> DeleteAsync(int id);
    }
}
