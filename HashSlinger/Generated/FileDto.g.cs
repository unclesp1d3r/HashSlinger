namespace HashSlinger.Api.Generated
{
    public partial class FileDto
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public long Size { get; set; }
        public bool IsSecret { get; set; }
        public int FileType { get; set; }
        public int AccessGroupId { get; set; }
        public long? LineCount { get; set; }
        public Guid? FileGuid { get; set; }
        public AccessGroupDto AccessGroup { get; set; }
        public ICollection<FileDownloadDto> FileDownloads { get; set; }
        public ICollection<PreconfiguredTaskDto> PreconfiguredTasks { get; set; }
        public ICollection<FileTaskDto> FileTasks { get; set; }
    }
}