using System;
using System.Collections.Generic;
using HashSlinger.Shared.Generated;

namespace HashSlinger.Shared.Generated
{
    public partial record AgentDto
    {
        public ICollection<AccessGroupDto> AccessGroups { get; set; }
        public ICollection<AssignmentDto> Assignments { get; set; }
        public ICollection<ChunkDto> Chunks { get; set; }
        public ICollection<AgentErrorDto> Errors { get; set; }
        public ICollection<HealthCheckAgentDto> HealthCheckAgents { get; set; }
        public ICollection<SpeedDto> Speeds { get; set; }
        public ICollection<AgentStatDto> Stats { get; set; }
        public UserDto? User { get; set; }
        public ICollection<ZapDto> Zaps { get; set; }
        public string ClientSignature { get; set; }
        public string CommandParameters { get; set; }
        public bool CpuOnly { get; set; }
        public List<string> Devices { get; set; }
        public int Id { get; set; }
        public bool IgnoreErrors { get; set; }
        public bool IsActive { get; set; }
        public bool IsTrusted { get; set; }
        public string LastAction { get; set; }
        public string? LastSeenIpAddress { get; set; }
        public DateTime LastSeenTime { get; set; }
        public string Name { get; set; }
        public string OperatingSystem { get; set; }
        public string Token { get; set; }
        public string Uid { get; set; }
        public int? UserId { get; set; }
    }
}