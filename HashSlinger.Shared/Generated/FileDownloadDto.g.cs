using System;
using HashSlinger.Shared.Generated;

namespace HashSlinger.Shared.Generated
{
    public partial record FileDownloadDto
    {
        public FileDto File { get; set; }
        public int FileId { get; set; }
        public int Id { get; set; }
        public int Status { get; set; }
        public DateTime Time { get; set; }
    }
}