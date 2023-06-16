using System;
using System.Collections.Generic;
using HashSlinger.Api.Generated;

namespace HashSlinger.Api.Generated
{
    public partial class ChunkDto
    {
        public int Id { get; set; }
        public int TaskId { get; set; }
        public ulong Skip { get; set; }
        public ulong Length { get; set; }
        public int? AgentId { get; set; }
        public DateTime DispatchTime { get; set; }
        public DateTime SolveTime { get; set; }
        public ulong Checkpoint { get; set; }
        public int? Progress { get; set; }
        public int State { get; set; }
        public int Cracked { get; set; }
        public ulong Speed { get; set; }
        public AgentDto? Agent { get; set; }
        public ICollection<HashBinaryDto> HashBinaries { get; set; }
        public ICollection<HashDto> Hashes { get; set; }
        public TaskDto Task { get; set; }
    }
}