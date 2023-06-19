using System.Collections.Generic;
using HashSlinger.Shared.Generated;

namespace HashSlinger.Shared.Generated
{
    public partial record CrackerBinaryTypeDto
    {
        public ICollection<CrackerBinaryDto> CrackerBinaries { get; set; }
        public ICollection<PreconfiguredTaskDto> Pretasks { get; set; }
        public ICollection<TaskDto> Tasks { get; set; }
        public int Id { get; set; }
        public bool IsChunkingAvailable { get; set; }
        public string TypeName { get; set; }
    }
}