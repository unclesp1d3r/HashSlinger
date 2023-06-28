using HashSlinger.Shared.Generated;

namespace HashSlinger.Shared.Generated
{
    public partial record TaskDebugOutputDto
    {
        public TaskDto Task { get; set; }
        public int Id { get; set; }
        public string Output { get; set; }
        public int TaskId { get; set; }
    }
}