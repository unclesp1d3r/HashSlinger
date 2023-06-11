using System;
using HashSlinger.Api.Generated;

namespace HashSlinger.Api.Generated
{
    public partial class SessionDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime SessionStartDate { get; set; }
        public DateTime LastActionDate { get; set; }
        public bool IsOpen { get; set; }
        public int SessionLifetime { get; set; }
        public string SessionKey { get; set; }
        public UserDto User { get; set; }
    }
}