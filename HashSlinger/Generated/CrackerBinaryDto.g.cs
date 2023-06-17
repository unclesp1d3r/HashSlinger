using System.Collections.Generic;
using HashSlinger.Api.Generated;

namespace HashSlinger.Api.Generated
{
    public partial record CrackerBinaryDto
    {
        public CrackerBinaryTypeDto CrackerBinaryType { get; set; }
        public ICollection<HealthCheckDto> HealthChecks { get; set; }
        public ICollection<TaskDto> Tasks { get; set; }
        public string DownloadUrl { get; set; }
        public string Executable { get; set; }
        public FileDto? File { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public List<string> OperatingSystems { get; set; }
        public string Version { get; set; }
    }
}