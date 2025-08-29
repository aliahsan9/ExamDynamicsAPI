using AutoMapper; // Make sure this is included
using ExamDynamicsAPI.Core.DTOs;
using ExamDynamicsAPI.Core.DTOs.FeedbackDTOs;
using ExamDynamicsAPI.Core.Models;

namespace ExamDynamicsAPI.Applications.Mappings
{
    public class FeedbackMappingProfile : AutoMapper.Profile
    {
        public FeedbackMappingProfile()
        {
            CreateMap<FeedbackCreateDto, Feedback>();
            CreateMap<FeedbackUpdateDto, Feedback>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<Feedback, FeedbackReadDto>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User != null ? src.User.FullName : null));
        }
    } 
}
