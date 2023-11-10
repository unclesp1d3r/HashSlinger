using System;
using System.Collections.Generic;
using HashSlinger.Shared.Generated;

namespace HashSlinger.Shared.Generated
{
    public partial record FileDto
    {
        public AccessGroupDto AccessGroup { get; set; }
        public ICollection<FileDownloadDto> FileDownloads { get; set; }
        public ICollection<PreconfiguredTaskDto> PreconfiguredTasks { get; set; }
        public ICollection<TaskDto> Tasks { get; set; }
        public int AccessGroupId { get; set; }
        public Guid? FileGuid { get; set; }
        public string FileName { get; set; }
        public string FileType { get; set; }
        public int Id { get; set; }
        public bool IsSecret { get; set; }
        public int? LineCount { get; set; }
        public long Size { get; set; }
    }
}