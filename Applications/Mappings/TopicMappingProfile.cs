using AutoMapper;
using ExamDynamicsAPI.Core.DTOs.TopicDTOs;
using ExamDynamicsAPI.Core.Models;
namespace ExamDynamicsAPI.Applications.Mappings

{
    public class TopicMappingProfile : AutoMapper.Profile
    {
        public TopicMappingProfile()
        {
            CreateMap<Topic, TopicDto>().ReverseMap();
            CreateMap<CreateTopicDto, Topic>();
            CreateMap<UpdateTopicDto, Topic>();
        }
    }
}
