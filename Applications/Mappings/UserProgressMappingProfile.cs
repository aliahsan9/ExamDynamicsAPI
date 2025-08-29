using AutoMapper;
using ExamDynamicsAPI.Core.DTOs.UserExamProgressDTOs;
using ExamDynamicsAPI.Core.DTOs.UserProfileDTOs;
using ExamDynamicsAPI.Core.Models;
namespace ExamDynamicsAPI.Applications.Mappings

{
    public class UserProgressMappingProfile : AutoMapper.Profile
    {
        public UserProgressMappingProfile()
        { 
            // UserProfile mappings
            CreateMap<UserProfileCreateDto, UserProfile>();
            CreateMap<UserProfileUpdateDto, UserProfile>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<UserProfile, UserProfileReadDto>();
            CreateMap<UserProgress, UserExamProgressDto>();

        }
    }
}
