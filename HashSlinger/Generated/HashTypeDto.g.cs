using System;
using System.Collections.Generic;
using HashSlinger.Api.Generated;

namespace HashSlinger.Api.Generated
{
    public partial record HashTypeDto
    {
        public ICollection<HashlistDto> Hashlists { get; set; }
        public string Description { get; set; }
        public Guid Id { get; set; }
        public int HashcatId { get; set; }
        public bool IsSalted { get; set; }
        public bool IsSlowHash { get; set; }
        public ICollection<HealthCheckDto> HealthChecks { get; set; }
    }
}