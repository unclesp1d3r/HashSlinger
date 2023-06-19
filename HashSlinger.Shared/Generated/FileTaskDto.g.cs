using HashSlinger.Api.Generated;

namespace HashSlinger.Api.Generated
{
    using Shared.Generated;

    public partial record FileTaskDto
    {
        public FileDto File { get; set; }
        public TaskDto Task { get; set; }
        public int FileId { get; set; }
        public int Id { get; set; }
        public int TaskId { get; set; }
    }
}
