using ExamDynamicsAPI.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExamDynamicsAPI.Core.Interfaces.Repositories
{
    public interface IBookmarkRepository
    {
        Task<IEnumerable<Bookmark>> GetAllAsync();
        Task<Bookmark?> GetByIdAsync(int id);
        Task AddAsync(Bookmark bookmark);
        Task UpdateAsync(Bookmark bookmark);
        Task DeleteAsync(Bookmark bookmark);
        Task<IEnumerable<Bookmark>> GetByUserIdAsync(int userId);
    }
}
