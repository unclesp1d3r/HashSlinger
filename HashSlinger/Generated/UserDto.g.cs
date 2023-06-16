namespace HashSlinger.Api.Generated
{
    public partial class UserDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public bool IsValid { get; set; }
        public DateTime LastLoginDate { get; set; }
        public DateTime RegisteredSince { get; set; }
        public ICollection<AccessGroupDto> AccessGroups { get; set; }
        public ICollection<ApiKeyDto> ApiKeys { get; set; }
        public ICollection<NotificationSettingDto> NotificationSettings { get; set; }
        public ICollection<SessionDto> Sessions { get; set; }
    }
}