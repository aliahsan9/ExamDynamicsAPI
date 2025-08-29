using AutoMapper;
using ExamDynamicsAPI.Core.DTOs.BlogPostDTOs;
using ExamDynamicsAPI.Core.Models;
namespace ExamDynamicsAPI.Applications.Mappings

{
    public class BlogPostMappingProfile : AutoMapper.Profile
    {
        public BlogPostMappingProfile()
        {
            CreateMap<BlogPost, BlogPostDto>().ReverseMap();
            CreateMap<CreateBlogPostDto, BlogPost>();
            CreateMap<UpdateBlogPostDto, BlogPost>();
        }
    }
}
