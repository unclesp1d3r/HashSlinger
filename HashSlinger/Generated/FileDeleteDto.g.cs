using System;

namespace HashSlinger.Api.Generated
{
    public partial record FileDeleteDto
    {
        public string FileName { get; set; }
        public int Id { get; set; }
        public DateTime Time { get; set; }
    }
}