namespace HashSlinger.Api.Generated
{
    public partial class HashTypeDto
    {
        public ICollection<HashlistDto> Hashlists { get; set; }
        public string Description { get; set; }
        public int Id { get; set; }
        public bool IsSalted { get; set; }
        public bool IsSlowHash { get; set; }
    }
}