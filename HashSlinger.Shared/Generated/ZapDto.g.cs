using HashSlinger.Shared.Generated;

namespace HashSlinger.Shared.Generated
{
    public partial record ZapDto
    {
        public AgentDto? Agent { get; set; }
        public HashlistDto Hashlist { get; set; }
        public int? AgentId { get; set; }
        public string Hash { get; set; }
        public int HashlistId { get; set; }
        public int Id { get; set; }
        public long SolveTime { get; set; }
    }
}