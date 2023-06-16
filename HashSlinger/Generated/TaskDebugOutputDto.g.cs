namespace HashSlinger.Api.Generated
{
    public partial class TaskDebugOutputDto
    {
        public int Id { get; set; }
        public int TaskId { get; set; }
        public string Output { get; set; }
        public TaskDto Task { get; set; }
    }
}