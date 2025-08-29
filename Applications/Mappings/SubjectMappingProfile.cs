using AutoMapper;
using ExamDynamicsAPI.Core.DTOs.SubjectDTOs;
using ExamDynamicsAPI.Core.Models;
namespace ExamDynamicsAPI.Applications.Mappings

{
    public class SubjectMappingProfile : AutoMapper.Profile
    {
        public SubjectMappingProfile()
        {
            CreateMap<Subject, SubjectDto>().ReverseMap();
            CreateMap<CreateSubjectDto, Subject>();
            CreateMap<SubjectUpdateDto, Subject>();
        }
    }
}
