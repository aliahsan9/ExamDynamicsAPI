using AutoMapper;
using ExamDynamicsAPI.Core.DTOs;
using ExamDynamicsAPI.Core.DTOs.ExamMaterialDTOs;
using ExamDynamicsAPI.Core.Models;

namespace ExamDynamicsAPI.Applications.Mappings
{
    public class ExamMaterialMappingProfile : AutoMapper.Profile
    {
        public ExamMaterialMappingProfile()
        {
            CreateMap<ExamMaterialCreateDto, ExamMaterial>();
            CreateMap<ExamMaterialUpdateDto, ExamMaterial>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<ExamMaterial, ExamMaterialReadDto>()
                .ForMember(dest => dest.ExamTitle, opt => opt.MapFrom(src => src.Exam != null ? src.Exam.Title : null))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User != null ? src.User.FullName : null));
        }
    }
}
