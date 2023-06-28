using System;
using HashSlinger.Shared.Generated;

namespace HashSlinger.Shared.Generated
{
    public partial record ApiKeyDto
    {
        public ApiGroupDto ApiGroup { get; set; }
        public UserDto User { get; set; }
        public int AccessCount { get; set; }
        public string AccessKey { get; set; }
        public int ApiGroupId { get; set; }
        public DateTime EndValid { get; set; }
        public int Id { get; set; }
        public DateTime StartValid { get; set; }
        public int UserId { get; set; }
    }
}