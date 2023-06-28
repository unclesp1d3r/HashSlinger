using System.Collections.Generic;
using HashSlinger.Shared.Generated;

namespace HashSlinger.Shared.Generated
{
    public partial record TaskWrapperDto
    {
        public AccessGroupDto? AccessGroup { get; set; }
        public HashlistDto Hashlist { get; set; }
        public ICollection<TaskDto> Tasks { get; set; }
        public int? AccessGroupId { get; set; }
        public int Cracked { get; set; }
        public int HashlistId { get; set; }
        public int Id { get; set; }
        public bool IsArchived { get; set; }
        public string Name { get; set; }
        public int Priority { get; set; }
        public int TaskType { get; set; }
    }
}