using AutoMapper;
using ExamDynamicsAPI.Core.Models;
using ExamDynamicsAPI.Core.DTOs;
using ExamDynamicsAPI.Core.DTOs.StudyMaterialDTOs;

namespace ExamDynamicsAPI.Applications.Mappings
{
    public class StudyMaterialMappingProfile : AutoMapper.Profile
    {
        public StudyMaterialMappingProfile()
        {
            // Map StudyMaterial -> StudyMaterialDto
            CreateMap<StudyMaterial, StudyMaterialDto>()
                .ForMember(dest => dest.TopicName, opt => opt.MapFrom(src => src.Topic != null ? src.Topic.Name : string.Empty));

            // Map CreateStudyMaterialDto -> StudyMaterial
            CreateMap<CreateStudyMaterialDto, StudyMaterial>();

            // Map UpdateStudyMaterialDto -> StudyMaterial
            CreateMap<UpdateStudyMaterialDto, StudyMaterial>();
        }
    }
}
