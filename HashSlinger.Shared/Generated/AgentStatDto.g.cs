using System;
using HashSlinger.Shared.Generated;

namespace HashSlinger.Shared.Generated
{
    public partial record AgentStatDto
    {
        public AgentDto Agent { get; set; }
        public int AgentId { get; set; }
        public int Id { get; set; }
        public int StatType { get; set; }
        public DateTime Time { get; set; }
        public string Value { get; set; }
    }
}