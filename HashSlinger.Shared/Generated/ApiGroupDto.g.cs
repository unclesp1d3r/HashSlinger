using System.Collections.Generic;
using HashSlinger.Shared.Generated;

namespace HashSlinger.Shared.Generated
{
    public partial record ApiGroupDto
    {
        public ICollection<ApiKeyDto> ApiKeys { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Permissions { get; set; }
    }
}