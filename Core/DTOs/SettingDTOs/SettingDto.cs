namespace ExamDynamicsAPI.Core.DTOs.settingDTOs
{
    public class SettingDto
    {
        public int SettingId { get; set; }
        public string Key { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
