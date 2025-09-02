// Interfaces/Services/IContactMessageService.cs
using ExamDynamicsAPI.Core.DTOs.ContactMessageDTOs;
using System.Threading.Tasks;

namespace ExamDynamicsAPI.Core.Interfaces.Services
{
    public interface IContactMessageService
    {
        Task SendMessageAsync(ContactMessageDto dto);
    }
}
