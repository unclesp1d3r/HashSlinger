using System.Collections.Generic;
using HashSlinger.Shared.Generated;

namespace HashSlinger.Shared.Generated
{
    public partial record PreconfiguredTaskDto
    {
        public CrackerBinaryTypeDto CrackerBinaryType { get; set; }
        public ICollection<FileDto> Files { get; set; }
        public ICollection<SupertaskPretaskDto> SupertaskPretasks { get; set; }
        public string AttackCommand { get; set; }
        public int ChunkTime { get; set; }
        public string? Color { get; set; }
        public int CrackerBinaryTypeId { get; set; }
        public int Id { get; set; }
        public bool IsCpuTask { get; set; }
        public bool IsMaskImport { get; set; }
        public bool IsSmall { get; set; }
        public int MaxAgents { get; set; }
        public string Name { get; set; }
        public int Priority { get; set; }
        public int StatusTimer { get; set; }
        public bool UseNewBench { get; set; }
    }
}