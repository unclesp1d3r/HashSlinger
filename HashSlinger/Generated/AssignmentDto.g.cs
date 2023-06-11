using HashSlinger.Api.Generated;

namespace HashSlinger.Api.Generated
{
    public partial class AssignmentDto
    {
        public int Id { get; set; }
        public int TaskId { get; set; }
        public int AgentId { get; set; }
        public string Benchmark { get; set; }
        public AgentDto Agent { get; set; }
        public TaskDto Task { get; set; }
    }
}