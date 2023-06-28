using System;
using System.Collections.Generic;
using HashSlinger.Shared.Generated;

namespace HashSlinger.Shared.Generated
{
    public partial record ChunkDto
    {
        public AgentDto? Agent { get; set; }
        public ICollection<BinaryHashDto> BinaryHashes { get; set; }
        public ICollection<HashDto> Hashes { get; set; }
        public ICollection<AgentErrorDto> Errors { get; set; }
        public TaskDto Task { get; set; }
        public int? AgentId { get; set; }
        public ulong Checkpoint { get; set; }
        public int Cracked { get; set; }
        public DateTime DispatchTime { get; set; }
        public int Id { get; set; }
        public ulong Length { get; set; }
        public int? Progress { get; set; }
        public ulong Skip { get; set; }
        public DateTime SolveTime { get; set; }
        public ulong Speed { get; set; }
        public int State { get; set; }
        public int TaskId { get; set; }
    }
}