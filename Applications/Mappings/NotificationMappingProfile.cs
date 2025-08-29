using AutoMapper;
using ExamDynamicsAPI.Core.DTOs.NotificationDTOs;
using ExamDynamicsAPI.Core.Models;

namespace ExamDynamicsAPI.Applications.Mappings
{
    public class NotificationMappingProfile : AutoMapper.Profile
    {
        public NotificationMappingProfile()
        {
            CreateMap<NotificationCreateDto, Notification>();

            CreateMap<NotificationUpdateDto, Notification>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Notification, NotificationReadDto>()
                .ForMember(dest => dest.UserName, 
                           opt => opt.MapFrom(src => src.User != null ? src.User.FullName : null));
        }
    }
}
