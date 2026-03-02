using ExamDynamicsAPI.Core.Models;
using ExamDynamicsAPI.Core.DTOs.MessageDTOs;

namespace ExamDynamicsAPI.Applications.Mappings
{
    public class MessageMappingProfile : AutoMapper.Profile
    {
        public MessageMappingProfile() // must be in constructor
        {
            // Mapping DTO -> Model
            CreateMap<MessageCreateDto, Message>();
            CreateMap<MessageUpdateDto, Message>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            // Mapping Model -> DTO
            CreateMap<Message, MessageReadDto>()
                .ForMember(dest => dest.SenderName, opt => opt.MapFrom(src => src.Sender != null ? src.Sender.FullName : null))
                .ForMember(dest => dest.ReceiverName, opt => opt.MapFrom(src => src.Receiver != null ? src.Receiver.FullName : null));
        }
    }
}
