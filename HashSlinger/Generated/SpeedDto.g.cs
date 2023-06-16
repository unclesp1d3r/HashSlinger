namespace HashSlinger.Api.Generated
{
    public partial class SpeedDto
    {
        public int Id { get; set; }
        public int AgentId { get; set; }
        public int TaskId { get; set; }
        public ulong SpeedValue { get; set; }
        public DateTime Time { get; set; }
        public AgentDto Agent { get; set; }
        public TaskDto Task { get; set; }
    }
}