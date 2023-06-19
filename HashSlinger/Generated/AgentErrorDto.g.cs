using System;
using HashSlinger.Api.Generated;

namespace HashSlinger.Api.Generated
{
    public partial record AgentErrorDto
    {
        public AgentDto Agent { get; set; }
        public TaskDto? Task { get; set; }
        public int? ChunkId { get; set; }
        public string Error { get; set; }
        public int Id { get; set; }
        public DateTime Time { get; set; }
    }
}