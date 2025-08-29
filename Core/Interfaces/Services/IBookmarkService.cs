using ExamDynamicsAPI.Core.DTOs.BookmarkDTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExamDynamicsAPI.Core.Interfaces.Services
{
    public interface IBookmarkService
    {
        Task<IEnumerable<BookmarkDto>> GetAllAsync();
        Task<BookmarkDto?> GetByIdAsync(int id);
        Task<BookmarkDto> CreateAsync(CreateBookmarkDto dto);
        Task<bool> UpdateAsync(int id, UpdateBookmarkDto dto);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<BookmarkDto>> GetByUserIdAsync(int userId);
    }
}
