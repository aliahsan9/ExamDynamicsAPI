using AutoMapper;
using ExamDynamicsAPI.Core.DTOs.FaqDTOs;
using ExamDynamicsAPI.Core.Models;
namespace ExamDynamicsAPI.Applications.Mappings

{
    public class FaqMappingProfile : AutoMapper.Profile
    {
        public FaqMappingProfile()
        {
            CreateMap<Faq, FaqDto>().ReverseMap();
            CreateMap<CreateFaqDto, Faq>();
            CreateMap<UpdateFaqDto, Faq>();
        }
    }
}
