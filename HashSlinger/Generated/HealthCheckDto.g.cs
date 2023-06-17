using System;
using System.Collections.Generic;
using HashSlinger.Api.Generated;

namespace HashSlinger.Api.Generated
{
    public partial record HealthCheckDto
    {
        public CrackerBinaryDto CrackerBinary { get; set; }
        public ICollection<HealthCheckAgentDto> HealthCheckAgents { get; set; }
        public string AttackCmd { get; set; }
        public int CheckType { get; set; }
        public int CrackerBinaryId { get; set; }
        public int ExpectedCracks { get; set; }
        public int HashtypeId { get; set; }
        public int Id { get; set; }
        public int Status { get; set; }
        public DateTime Time { get; set; }
    }
}