using System;

namespace HashSlinger.Shared.Generated
{
    public partial record RegistrationVoucherDto
    {
        public int? AccessGroupId { get; set; }
        public DateTime? Expiration { get; set; }
        public int Id { get; set; }
        public string Voucher { get; set; }
    }
}