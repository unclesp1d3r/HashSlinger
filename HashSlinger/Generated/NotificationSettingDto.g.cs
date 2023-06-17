using HashSlinger.Api.Generated;

namespace HashSlinger.Api.Generated
{
    public partial record NotificationSettingDto
    {
        public UserDto User { get; set; }
        public string Action { get; set; }
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public string Notification { get; set; }
        public int? ObjectId { get; set; }
        public string Receiver { get; set; }
        public int UserId { get; set; }
    }
}