using System.Collections.Generic;
using HashSlinger.Api.Generated;

namespace HashSlinger.Api.Generated
{
    public partial class ApiGroupDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Permissions { get; set; }
        public ICollection<ApiKeyDto> ApiKeys { get; set; }
    }
}