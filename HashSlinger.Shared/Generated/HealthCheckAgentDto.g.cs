using System.Collections.Generic;
using HashSlinger.Shared.Generated;

namespace HashSlinger.Shared.Generated
{
    public partial record HealthCheckAgentDto
    {
        public AgentDto Agent { get; set; }
        public HealthCheckDto HealthCheck { get; set; }
        public int? Cracked { get; set; }
        public ulong? End { get; set; }
        public List<string> Errors { get; set; }
        public int Id { get; set; }
        public int? NumGpus { get; set; }
        public ulong? Start { get; set; }
        public HealthCheckStatusDto Status { get; set; }
    }
}