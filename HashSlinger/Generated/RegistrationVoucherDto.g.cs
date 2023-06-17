using System;
using HashSlinger.Api.Generated;

namespace HashSlinger.Api.Generated
{
    public partial class RegistrationVoucherDto
    {
        public AccessGroupDto? AccessGroup { get; set; }
        public DateTime? Expiration { get; set; }
        public int Id { get; set; }
        public string Voucher { get; set; }
    }
}