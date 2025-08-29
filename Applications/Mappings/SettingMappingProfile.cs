using AutoMapper;
using ExamDynamicsAPI.Core.Models;
using ExamDynamicsAPI.Core.DTOs.settingDTOs;

namespace ExamDynamicsAPI.Applications.Mappings
{
    public class SettingMappingProfile : AutoMapper.Profile
    {
        public SettingMappingProfile()
        {
            // Model → DTO
            CreateMap<Setting, SettingDto>();

            // DTO → Model
            CreateMap<CreateSettingDto, Setting>();
            CreateMap<UpdateSettingDto, Setting>();
        }
    }
}
