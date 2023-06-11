using HashSlinger.Api.Generated;

namespace HashSlinger.Api.Generated
{
    public partial class FileTaskDto
    {
        public int Id { get; set; }
        public int FileId { get; set; }
        public int TaskId { get; set; }
        public FileDto File { get; set; }
        public TaskDto Task { get; set; }
    }
}