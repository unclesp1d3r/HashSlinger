using HashSlinger.Shared.Generated;

namespace HashSlinger.Shared.Generated
{
    public partial record SupertaskPretaskDto
    {
        public PreconfiguredTaskDto PreconfiguredTask { get; set; }
        public SupertaskDto Supertask { get; set; }
        public int Id { get; set; }
        public int PretaskId { get; set; }
        public int SupertaskId { get; set; }
    }
}