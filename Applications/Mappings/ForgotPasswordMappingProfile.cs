using AutoMapper;
using ExamDynamicsAPI.Core.DTOs.ForgotPasswordDTOs;
using ExamDynamicsAPI.Core.Models;

namespace ExamDynamicsAPI.Applications.Mappings
{
    public class ForgotPasswordMappingProfile : AutoMapper.Profile
    {
        public ForgotPasswordMappingProfile()
        {
            CreateMap<ForgotPassword, ForgotPasswordDto>().ReverseMap();
            CreateMap<ForgotPasswordCreateDto, ForgotPassword>();
            CreateMap<ForgotPasswordResetDto, ForgotPassword>();
        }
    }
}
 