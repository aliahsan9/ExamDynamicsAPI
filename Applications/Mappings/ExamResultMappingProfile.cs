using AutoMapper;
using ExamDynamicsAPI.Core.Models;
using ExamDynamicsAPI.Core.DTOs.ExamResultDTOs;

namespace ExamDynamicsAPI.Applications.Mappings
{
    public class ExamResultMappingProfile : AutoMapper.Profile
    {
        public ExamResultMappingProfile()
        {
            // Entity <-> DTO
            CreateMap<ExamResult, ExamResultDto>().ReverseMap();

            // For create/update DTOs if you have them
            CreateMap<ExamResultCreateDto, ExamResult>();
            CreateMap<ExamResultUpdateDto, ExamResult>();
        }
    }
}
