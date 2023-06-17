using System;
using HashSlinger.Api.Generated;

namespace HashSlinger.Api.Generated
{
    public partial class SpeedDto
    {
        public AgentDto Agent { get; set; }
        public TaskDto Task { get; set; }
        public int AgentId { get; set; }
        public int Id { get; set; }
        public ulong SpeedValue { get; set; }
        public int TaskId { get; set; }
        public DateTime Time { get; set; }
    }
}