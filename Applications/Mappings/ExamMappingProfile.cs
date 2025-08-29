using AutoMapper;
using ExamDynamicsAPI.Core.DTOs.ExamDTOs;
using ExamDynamicsAPI.Core.Models;
namespace ExamDynamicsAPI.Applications.Mappings

{
    public class ExamMappingProfile : AutoMapper.Profile
    {
        public ExamMappingProfile()
        {
            CreateMap<Exam, ExamDto>().ReverseMap();
            CreateMap<CreateExamDto, Exam>();
            CreateMap<UpdateExamDto, Exam>();
        }
    }
}
