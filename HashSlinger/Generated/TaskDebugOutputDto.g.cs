using HashSlinger.Api.Generated;

namespace HashSlinger.Api.Generated
{
    public partial class TaskDebugOutputDto
    {
        public TaskDto Task { get; set; }
        public int Id { get; set; }
        public string Output { get; set; }
        public int TaskId { get; set; }
    }
}