using HashSlinger.Shared.Generated;

namespace HashSlinger.Shared.Generated
{
    public partial record AssignmentDto
    {
        public AgentDto Agent { get; set; }
        public TaskDto Task { get; set; }
        public int AgentId { get; set; }
        public string Benchmark { get; set; }
        public int Id { get; set; }
        public int TaskId { get; set; }
    }
}