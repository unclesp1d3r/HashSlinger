using System;
using HashSlinger.Shared.Generated;

namespace HashSlinger.Shared.Generated
{
    public partial record RegistrationVoucherDto
    {
        public AccessGroupDto? AccessGroup { get; set; }
        public DateTime? Expiration { get; set; }
        public int Id { get; set; }
        public string Voucher { get; set; }
    }
}