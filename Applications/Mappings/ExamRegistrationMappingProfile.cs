using AutoMapper;
using ExamDynamicsAPI.Core.DTOs.ExamRegistrationDTOs;
using ExamDynamicsAPI.Core.Models;

namespace ExamDynamicsAPI.Applications.Mappings
{
    public class ExamRegistrationMappingProfile : AutoMapper.Profile
    {
        public ExamRegistrationMappingProfile()
        {
            // Entity → DTO
            CreateMap<ExamRegistration, ExamRegistrationDto>();

            // CreateDto → Entity
            CreateMap<ExamRegistrationCreateDto, ExamRegistration>();

            // UpdateDto → Entity
            CreateMap<ExamRegistrationUpdateDto, ExamRegistration>();
        }
    }
}
