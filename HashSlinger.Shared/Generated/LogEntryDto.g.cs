using System;

namespace HashSlinger.Shared.Generated
{
    public partial record LogEntryDto
    {
        public Guid Id { get; set; }
        public string Issuer { get; set; }
        public string Level { get; set; }
        public string Message { get; set; }
        public DateTime Time { get; set; }
    }
}