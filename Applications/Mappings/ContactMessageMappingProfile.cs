using AutoMapper;
using ExamDynamicsAPI.Core.DTOs.ContactMessageDTOs;
using ExamDynamicsAPI.Core.Models;
namespace ExamDynamicsAPI.Applications.Mappings

{
    public class ContactMessageMappingProfile : AutoMapper.Profile
    {
        public ContactMessageMappingProfile()
        {
            CreateMap<ContactMessage, ContactMessageDto>().ReverseMap();
            CreateMap<CreateContactMessageDto, ContactMessage>();
            CreateMap<UpdateContactMessageDto, ContactMessage>();
        }
    }
}
