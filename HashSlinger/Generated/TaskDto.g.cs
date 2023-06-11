using System.Collections.Generic;
using HashSlinger.Api.Generated;

namespace HashSlinger.Api.Generated
{
    public partial class TaskDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AttackCommand { get; set; }
        public int ChunkTime { get; set; }
        public int StatusTimer { get; set; }
        public ulong Keyspace { get; set; }
        public ulong KeyspaceProgress { get; set; }
        public int Priority { get; set; }
        public int MaxAgents { get; set; }
        public string? Color { get; set; }
        public bool IsSmall { get; set; }
        public bool IsCpuTask { get; set; }
        public bool UseNewBenchmark { get; set; }
        public ulong SkipKeyspace { get; set; }
        public int? CrackerBinaryId { get; set; }
        public int? CrackerBinaryTypeId { get; set; }
        public int TaskWrapperId { get; set; }
        public bool IsArchived { get; set; }
        public string Notes { get; set; }
        public int StaticChunks { get; set; }
        public ulong ChunkSize { get; set; }
        public bool ForcePipe { get; set; }
        public bool UsePreprocessor { get; set; }
        public string PreprocessorCommand { get; set; }
        public ICollection<AgentErrorDto> AgentErrors { get; set; }
        public ICollection<AssignmentDto> Assignments { get; set; }
        public ICollection<ChunkDto> Chunks { get; set; }
        public CrackerBinaryDto? CrackerBinary { get; set; }
        public CrackerBinaryTypeDto? CrackerBinaryType { get; set; }
        public ICollection<FileTaskDto> FileTasks { get; set; }
        public ICollection<SpeedDto> Speeds { get; set; }
        public ICollection<TaskDebugOutputDto> TaskDebugOutputs { get; set; }
        public TaskWrapperDto TaskWrapper { get; set; }
    }
}