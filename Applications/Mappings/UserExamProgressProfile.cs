using AutoMapper;
using ExamDynamicsAPI.Core.DTOs.UserExamProgressDTOs;
using ExamDynamicsAPI.Core.Models;

namespace ExamDynamicsAPI.Applications.Mappings
{
    public class UserExamProgressProfile : AutoMapper.Profile
    {
        public UserExamProgressProfile()
        {
            // Mapping from Entity to Read DTO
            CreateMap<UserExamProgress, UserExamProgressReadDto>();

            // Mapping from Create DTO to Entity
            CreateMap<UserExamProgressCreateDto, UserExamProgress>()
                .ForMember(dest => dest.StartedAt, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.CompletedAt, opt => opt.Ignore())
                .ForMember(dest => dest.CurrentQuestion, opt => opt.MapFrom(src => 0))
                .ForMember(dest => dest.Score, opt => opt.MapFrom(src => 0));

            // Mapping from Update DTO to Entity
            CreateMap<UserExamProgressUpdateDto, UserExamProgress>()
                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
