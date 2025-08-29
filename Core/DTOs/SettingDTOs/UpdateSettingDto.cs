using System.ComponentModel.DataAnnotations;

namespace ExamDynamicsAPI.Core.DTOs.settingDTOs
{
    public class UpdateSettingDto
    {
        [Required]
        public int SettingId { get; set; }

        [Required, MaxLength(100)]
        public string Key { get; set; } = string.Empty;

        [Required]
        public string Value { get; set; } = string.Empty;

        [MaxLength(250)]
        public string? Description { get; set; }
    }
}
