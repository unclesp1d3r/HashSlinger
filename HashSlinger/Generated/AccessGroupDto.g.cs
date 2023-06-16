using System.Collections.Generic;
using HashSlinger.Api.Generated;

namespace HashSlinger.Api.Generated
{
    public partial class AccessGroupDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<AgentDto> Agents { get; set; }
        public ICollection<UserDto> Users { get; set; }
        public ICollection<FileDto> Files { get; set; }
        public ICollection<HashlistDto> Hashlists { get; set; }
        public ICollection<TaskWrapperDto> TaskWrappers { get; set; }
    }
}