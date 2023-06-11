using System;
using HashSlinger.Api.Generated;

namespace HashSlinger.Api.Generated
{
    public partial class AgentStatDto
    {
        public int Id { get; set; }
        public int AgentId { get; set; }
        public int StatType { get; set; }
        public DateTime Time { get; set; }
        public string Value { get; set; }
        public AgentDto Agent { get; set; }
    }
}