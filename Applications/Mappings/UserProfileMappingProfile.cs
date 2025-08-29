using AutoMapper;
using ExamDynamicsAPI.Core.Models;
using ExamDynamicsAPI.Core.DTOs.UserProfileDTOs;

namespace ExamDynamicsAPI.Applications.Mappings
{
    // Fully qualify AutoMapper.Profile to avoid conflict
    public class UserProfileMappingProfile : AutoMapper.Profile
    {
        public UserProfileMappingProfile()
        {
            // Map your Profile model to DTOs
            CreateMap<ExamDynamicsAPI.Core.Models.Profile, UserProfileDto>().ReverseMap();
            CreateMap<UserProfileCreateDto, ExamDynamicsAPI.Core.Models.Profile>();
            CreateMap<UserProfileUpdateDto, ExamDynamicsAPI.Core.Models.Profile>();
        }
    }
}
