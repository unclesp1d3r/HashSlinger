using HashSlinger.Api.Generated;

namespace HashSlinger.Api.Generated
{
    public partial class SupertaskPretaskDto
    {
        public int Id { get; set; }
        public int SupertaskId { get; set; }
        public int PretaskId { get; set; }
        public PreconfiguredTaskDto PreconfiguredTask { get; set; }
        public SupertaskDto Supertask { get; set; }
    }
}