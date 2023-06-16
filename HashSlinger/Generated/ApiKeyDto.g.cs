namespace HashSlinger.Api.Generated
{
    public partial class ApiKeyDto
    {
        public int Id { get; set; }
        public DateTime StartValid { get; set; }
        public DateTime EndValid { get; set; }
        public string AccessKey { get; set; }
        public int AccessCount { get; set; }
        public int UserId { get; set; }
        public int ApiGroupId { get; set; }
        public ApiGroupDto ApiGroup { get; set; }
        public UserDto User { get; set; }
    }
}