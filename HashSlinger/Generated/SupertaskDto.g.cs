namespace HashSlinger.Api.Generated
{
    public partial class SupertaskDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<SupertaskPretaskDto> SupertaskPretasks { get; set; }
    }
}