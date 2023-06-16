namespace HashSlinger.Api.Generated
{
    public partial class CrackerBinaryTypeDto
    {
        public int Id { get; set; }
        public string TypeName { get; set; }
        public bool IsChunkingAvailable { get; set; }
        public ICollection<CrackerBinaryDto> CrackerBinaries { get; set; }
        public ICollection<PreconfiguredTaskDto> Pretasks { get; set; }
        public ICollection<TaskDto> Tasks { get; set; }
    }
}