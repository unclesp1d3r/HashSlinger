namespace HashSlinger.Api.Generated
{
    public partial class TaskWrapperDto
    {
        public int Id { get; set; }
        public int Priority { get; set; }
        public int TaskType { get; set; }
        public int HashlistId { get; set; }
        public int? AccessGroupId { get; set; }
        public string Name { get; set; }
        public bool IsArchived { get; set; }
        public int Cracked { get; set; }
        public AccessGroupDto? AccessGroup { get; set; }
        public HashlistDto Hashlist { get; set; }
        public ICollection<TaskDto> Tasks { get; set; }
    }
}