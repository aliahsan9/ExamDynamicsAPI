using AutoMapper;
using ExamDynamicsAPI.Core.DTOs.SubscriptionDTOs;
using ExamDynamicsAPI.Core.Models;

namespace ExamDynamicsAPI.Applications.Mappings
{
    public class SubscriptionMappingProfile : AutoMapper.Profile
    {
        public SubscriptionMappingProfile()
        {
            CreateMap<Subscription, SubscriptionDto>();
            CreateMap<SubscriptionCreateDto, Subscription>();
            CreateMap<SubscriptionUpdateDto, Subscription>();
        }
    }
}
