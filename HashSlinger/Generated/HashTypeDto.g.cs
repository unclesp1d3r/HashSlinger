using System.Collections.Generic;
using HashSlinger.Api.Generated;

namespace HashSlinger.Api.Generated
{
    public partial class HashTypeDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool IsSalted { get; set; }
        public bool IsSlowHash { get; set; }
        public ICollection<HashlistDto> Hashlists { get; set; }
    }
}