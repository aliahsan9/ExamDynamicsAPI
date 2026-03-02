using ExamDynamicsAPI.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExamDynamicsAPI.Core.Interfaces.Repositories
{
    public interface IAnnouncementRepository
    {
        Task<IEnumerable<Announcement>> GetAllAsync(); 
        Task<Announcement?> GetByIdAsync(int id);
        Task AddAsync(Announcement announcement);
        void Update(Announcement announcement);
        void Delete(Announcement announcement);
    }
}
