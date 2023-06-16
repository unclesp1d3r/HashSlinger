namespace HashSlinger.Api.Generated
{
    public partial class HealthCheckAgentDto
    {
        public AgentDto Agent { get; set; }
        public HealthCheckDto HealthCheck { get; set; }
        public int AgentId { get; set; }
        public int Cracked { get; set; }
        public DateTime End { get; set; }
        public string Errors { get; set; }
        public int HealthCheckId { get; set; }
        public int Id { get; set; }
        public int NumGpus { get; set; }
        public DateTime Start { get; set; }
        public int Status { get; set; }
    }
}