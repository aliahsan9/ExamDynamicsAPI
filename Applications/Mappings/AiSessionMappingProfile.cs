using AutoMapper;
using ExamDynamicsAPI.Core.DTOs.AITutorDTOs;
using ExamDynamicsAPI.Core.Models;
namespace ExamDynamicsAPI.Applications.Mappings

{
    public class AiSessionMappingProfile : AutoMapper.Profile
    {
        public AiSessionMappingProfile()
        {
            CreateMap<AiSession, AiSessionDto>().ReverseMap();
            CreateMap<CreateAiSessionDto, AiSession>();
            CreateMap<UpdateAiSessionDto, AiSession>();
        }
    }
}
