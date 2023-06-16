namespace HashSlinger.Api.Generated
{
    public partial class SessionDto
    {
        public UserDto User { get; set; }
        public int Id { get; set; }
        public bool IsOpen { get; set; }
        public DateTime LastActionDate { get; set; }
        public string SessionKey { get; set; }
        public int SessionLifetime { get; set; }
        public DateTime SessionStartDate { get; set; }
        public int UserId { get; set; }
    }
}