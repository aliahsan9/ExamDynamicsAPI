using AutoMapper;
using ExamDynamicsAPI.Core.DTOs.AnnouncementDTOs;
using ExamDynamicsAPI.Core.Models;
namespace ExamDynamicsAPI.Applications.Mappings

{
    public class AnnouncementMappingProfile : AutoMapper.Profile
    {
        public AnnouncementMappingProfile()
        {
            CreateMap<Announcement, AnnouncementDto>().ReverseMap();
            CreateMap<AnnouncementCreateDto, Announcement>();
            CreateMap<AnnouncementUpdateDto, Announcement>();
        }
    }
}
