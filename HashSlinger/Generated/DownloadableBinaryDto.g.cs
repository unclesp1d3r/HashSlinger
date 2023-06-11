using System.Collections.Generic;
using HashSlinger.Api.Generated;

namespace HashSlinger.Api.Generated
{
    public partial class DownloadableBinaryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string BinaryName { get; set; }
        public List<string> OperatingSystems { get; set; }
        public string Version { get; set; }
        public string DownloadUrl { get; set; }
        public FileDto? File { get; set; }
    }
}