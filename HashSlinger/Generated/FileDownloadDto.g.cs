using System;
using HashSlinger.Api.Generated;

namespace HashSlinger.Api.Generated
{
    public partial class FileDownloadDto
    {
        public FileDto File { get; set; }
        public int FileId { get; set; }
        public int Id { get; set; }
        public int Status { get; set; }
        public DateTime Time { get; set; }
    }
}