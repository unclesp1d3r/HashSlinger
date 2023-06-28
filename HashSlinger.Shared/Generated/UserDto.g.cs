using System;
using System.Collections.Generic;
using HashSlinger.Shared.Generated;

namespace HashSlinger.Shared.Generated
{
    public partial record UserDto
    {
        public ICollection<AccessGroupDto> AccessGroups { get; set; }
        public ICollection<ApiKeyDto> ApiKeys { get; set; }
        public ICollection<NotificationSettingDto> NotificationSettings { get; set; }
        public ICollection<SessionDto> Sessions { get; set; }
        public string Email { get; set; }
        public int Id { get; set; }
        public bool IsValid { get; set; }
        public DateTime LastLoginDate { get; set; }
        public DateTime RegisteredSince { get; set; }
        public string UserName { get; set; }
    }
}