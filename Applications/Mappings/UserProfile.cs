using AutoMapper;
using ExamDynamicsAPI.Core.DTOs.UserDTOs;
using ExamDynamicsAPI.Core.Models;
namespace ExamDynamicsAPI.Applications.Mappings

{
    public class UserMappingProfile : AutoMapper.Profile
    {
        public UserMappingProfile()
        {
            CreateMap<ApplicationUser, UserDto>().ReverseMap();
            CreateMap<CreateUserDto, ApplicationUser>();
            CreateMap<UpdateUserDto, ApplicationUser>();
        }
    }
}
