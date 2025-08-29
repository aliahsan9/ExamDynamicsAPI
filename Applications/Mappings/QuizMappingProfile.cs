using AutoMapper;
using ExamDynamicsAPI.Core.DTOs.QuizDTOs;
using ExamDynamicsAPI.Core.Models;
namespace ExamDynamicsAPI.Applications.Mappings
{
    public class QuizMappingProfile : AutoMapper.Profile
    {
        public QuizMappingProfile()
        {
            // Create
            CreateMap<QuizCreateDto, Quiz>();

            // Read
            CreateMap<Quiz, QuizDto>();

            // Update
            CreateMap<QuizUpdateDto, Quiz>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            // Optional: Map QuizDTO back to Quiz (if needed)
            CreateMap<QuizDto, Quiz>();
        }
    }
}