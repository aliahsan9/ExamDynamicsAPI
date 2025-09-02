// Interfaces/Repositories/IContactMessageRepository.cs
using ExamDynamicsAPI.Core.Models;
using System.Threading.Tasks;

namespace ExamDynamicsAPI.Core.Interfaces.Repositories
{
    public interface IContactMessageRepository
    {
        Task AddAsync(ContactMessage contactMessage);
    }
}
