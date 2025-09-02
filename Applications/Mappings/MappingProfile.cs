using AutoMapper;
using ExamDynamicsAPI.Core.DTOs.AiMessageDTOs;
using ExamDynamicsAPI.Core.DTOs.AITutorDTOs;
using ExamDynamicsAPI.Core.DTOs.AnnouncementDTOs;
using ExamDynamicsAPI.Core.DTOs.BlogPostDTOs;
using ExamDynamicsAPI.Core.DTOs.BookmarkDTOs;
using ExamDynamicsAPI.Core.DTOs.ExamDTOs;
using ExamDynamicsAPI.Core.DTOs.FaqDTOs;
using ExamDynamicsAPI.Core.DTOs.OptionDTOs;
using ExamDynamicsAPI.Core.DTOs.PaymentDTOs;
using ExamDynamicsAPI.Core.DTOs.QuestionDTOs;
using ExamDynamicsAPI.Core.DTOs.StudyMaterialDTOs;
using ExamDynamicsAPI.Core.DTOs.SubjectDTOs;
using ExamDynamicsAPI.Core.DTOs.TopicDTOs;
using ExamDynamicsAPI.Core.DTOs.UserDTOs;
using ExamDynamicsAPI.Core.DTOs.UserExamProgressDTOs;
using ExamDynamicsAPI.Core.DTOs.UserProfileDTOs;
using ExamDynamicsAPI.Core.Models;
namespace ExamDynamicsAPI.Applications.Mappings

{
    public class MappingProfile : AutoMapper.Profile
    {
        public MappingProfile()
        {
            // User
            CreateMap<ApplicationUser, UserDto>().ReverseMap();
            CreateMap<CreateUserDto, ApplicationUser>();
            CreateMap<UpdateUserDto, ApplicationUser>();

            // UserProfile
            CreateMap<UserProfile, UserProfileDto>().ReverseMap();
            CreateMap<UserProfileCreateDto, UserProfile>();
            CreateMap<UserProfileUpdateDto, UserProfile>();

            // Exam
            CreateMap<Exam, ExamDto>().ReverseMap();
            CreateMap<CreateExamDto, Exam>();
            CreateMap<UpdateExamDto, Exam>();
            CreateMap<Subject, SubjectDto>();
            // Payment mappings
            CreateMap<Payment, PaymentDto>().ReverseMap();
            CreateMap<CreatePaymentDto, Payment>();
            CreateMap<UpdatePaymentDto, Payment>();
            // Subject
            CreateMap<Subject, SubjectDto>().ReverseMap();
            CreateMap<CreateSubjectDto, Subject>();
            CreateMap<SubjectUpdateDto, Subject>();

            // Topic 
            CreateMap<Topic, TopicDto>().ReverseMap();
            CreateMap<CreateTopicDto, Topic>();
            CreateMap<UpdateTopicDto, Topic>();

            // Question
            CreateMap<Question, QuestionDto>().ReverseMap();
            CreateMap<CreateQuestionDto, Question>();
            CreateMap<UpdateQuestionDto, Question>();

            // Option
            CreateMap<Option, OptionDto>().ReverseMap();
            CreateMap<OptionCreateDto, Option>();
            CreateMap<OptionUpdateDTO, Option>();

            // StudyMaterial
            CreateMap<StudyMaterial, StudyMaterialDto>().ReverseMap();
            CreateMap<CreateStudyMaterialDto, StudyMaterial>();
            CreateMap<UpdateStudyMaterialDto, StudyMaterial>();

            // AiSession
            CreateMap<AiSession, AiSessionDto>().ReverseMap();
            CreateMap<CreateAiSessionDto, AiSession>();
            CreateMap<UpdateAiSessionDto, AiSession>();

  // ================= Announcement =================
            CreateMap<Announcement, AnnouncementReadDto>().ReverseMap();
            CreateMap<AnnouncementCreateDto, Announcement>();
            CreateMap<AnnouncementUpdateDto, Announcement>();
            // AiMessage
            CreateMap<AiMessage, AiMessageDto>().ReverseMap();
            CreateMap<CreateAiMessageDto, AiMessage>();
            CreateMap<UpdateAiMessageDto, AiMessage>();

            // Bookmark
            CreateMap<Bookmark, BookmarkDto>().ReverseMap();
            CreateMap<CreateBookmarkDto, Bookmark>();
            CreateMap<UpdateBookmarkDto, Bookmark>();     
    
            // UserProgress
            CreateMap<UserProgress, UserExamProgressDto>().ReverseMap();
            CreateMap<UserExamProgressCreateDto, UserProgress>();
            CreateMap<UserExamProgressUpdateDto, UserProgress>();

            // Announcement
            CreateMap<Announcement, AnnouncementDto>().ReverseMap();
            CreateMap<AnnouncementCreateDto, Announcement>();
            CreateMap<AnnouncementUpdateDto, Announcement>();

            // BlogPost (optional)
            CreateMap<BlogPost, BlogPostDto>().ReverseMap();
            CreateMap<CreateBlogPostDto, BlogPost>();
            CreateMap<UpdateBlogPostDto, BlogPost>();

            // Faq
            CreateMap<Faq, FaqDto>().ReverseMap();
            CreateMap<CreateFaqDto, Faq>();
            CreateMap<UpdateFaqDto, Faq>();
        }
    }
}
