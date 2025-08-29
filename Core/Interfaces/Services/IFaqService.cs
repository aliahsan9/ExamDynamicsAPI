using ExamDynamicsAPI.Core.DTOs.FaqDTOs;

namespace ExamDynamicsAPI.Core.Interfaces.Services

{
    public interface IFaqService
    {
        Task<IEnumerable<FaqDto>> GetAllAsync();
        Task<FaqDto?> GetByIdAsync(int id);
        Task<FaqDto> CreateAsync(FaqDto faqDto);
        Task<FaqDto?> UpdateAsync(int id, FaqDto faqDto);
        Task<bool> DeleteAsync(int id);
    }
}
