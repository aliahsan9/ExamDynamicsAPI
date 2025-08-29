using AutoMapper;
using ExamDynamicsAPI.Core.DTOs.QuestionBankDTOs;
using ExamDynamicsAPI.Core.Models;

namespace ExamDynamicsAPI.Applications.Mappings
{
    public class QuestionBankMappingProfile : AutoMapper.Profile
    {
        public QuestionBankMappingProfile()
        {
            CreateMap<QuestionBank, QuestionBankDto>().ReverseMap();
            CreateMap<QuestionBankCreateDto, QuestionBank>();
            CreateMap<QuestionBankUpdateDto, QuestionBank>();
        }
    }
}
