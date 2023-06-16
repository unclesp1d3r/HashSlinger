namespace HashSlinger.Api.Generated
{
    public partial class ZapDto
    {
        public int Id { get; set; }
        public string Hash { get; set; }
        public long SolveTime { get; set; }
        public int? AgentId { get; set; }
        public int HashlistId { get; set; }
        public AgentDto? Agent { get; set; }
        public HashlistDto Hashlist { get; set; }
    }
}