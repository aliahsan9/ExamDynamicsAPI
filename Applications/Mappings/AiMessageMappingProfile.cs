using AutoMapper;
using ExamDynamicsAPI.Core.DTOs.AiMessageDTOs;
using ExamDynamicsAPI.Core.Models;

namespace ExamDynamicsAPI.Applications.Mappings
{
    public class AiMessageMappingProfile : AutoMapper.Profile
    {
        public AiMessageMappingProfile()
        {
            CreateMap<AiMessage, AiMessageDto>().ReverseMap();
            CreateMap<CreateAiMessageDto, AiMessage>();
            CreateMap<UpdateAiMessageDto, AiMessage>();
        }
    }
}
