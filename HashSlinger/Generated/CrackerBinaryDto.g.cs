using System.Collections.Generic;
using HashSlinger.Api.Generated;

namespace HashSlinger.Api.Generated
{
    public partial class CrackerBinaryDto
    {
        public int Id { get; set; }
        public int CrackerBinaryTypeId { get; set; }
        public string Version { get; set; }
        public string DownloadUrl { get; set; }
        public string BinaryName { get; set; }
        public CrackerBinaryTypeDto CrackerBinaryType { get; set; }
        public ICollection<HealthCheckDto> HealthChecks { get; set; }
        public ICollection<TaskDto> Tasks { get; set; }
    }
}