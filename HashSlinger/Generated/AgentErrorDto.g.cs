using System;
using HashSlinger.Api.Generated;

namespace HashSlinger.Api.Generated
{
    public partial class AgentErrorDto
    {
        public int Id { get; set; }
        public int AgentId { get; set; }
        public int? TaskId { get; set; }
        public DateTime Time { get; set; }
        public string Error { get; set; }
        public int? ChunkId { get; set; }
        public AgentDto Agent { get; set; }
        public TaskDto? Task { get; set; }
    }
}