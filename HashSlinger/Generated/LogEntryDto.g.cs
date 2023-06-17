using System;
using HashSlinger.Api.Generated;

namespace HashSlinger.Api.Generated
{
    public partial class LogEntryDto
    {
        public Guid Id { get; set; }
        public string Issuer { get; set; }
        public LogEntryLevelsDto Level { get; set; }
        public string Message { get; set; }
        public DateTime Time { get; set; }
    }
}