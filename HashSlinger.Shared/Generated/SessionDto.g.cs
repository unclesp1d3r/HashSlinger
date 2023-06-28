using System;
using HashSlinger.Shared.Generated;

namespace HashSlinger.Shared.Generated
{
    public partial record SessionDto
    {
        public UserDto User { get; set; }
        public int Id { get; set; }
        public bool IsOpen { get; set; }
        public DateTime LastActionDate { get; set; }
        public string SessionKey { get; set; }
        public int SessionLifetime { get; set; }
        public DateTime SessionStartDate { get; set; }
        public int UserId { get; set; }
    }
}