using System;
using System.Collections.Generic;
using HashSlinger.Api.Generated;

namespace HashSlinger.Api.Generated
{
    public partial record FileDto
    {
        public AccessGroupDto AccessGroup { get; set; }
        public ICollection<FileDownloadDto> FileDownloads { get; set; }
        public ICollection<FileTaskDto> FileTasks { get; set; }
        public ICollection<PreconfiguredTaskDto> PreconfiguredTasks { get; set; }
        public int AccessGroupId { get; set; }
        public Guid? FileGuid { get; set; }
        public string FileName { get; set; }
        public int FileType { get; set; }
        public int Id { get; set; }
        public bool IsSecret { get; set; }
        public long? LineCount { get; set; }
        public long Size { get; set; }
    }
}