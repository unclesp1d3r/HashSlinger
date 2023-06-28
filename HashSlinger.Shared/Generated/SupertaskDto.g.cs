using System.Collections.Generic;
using HashSlinger.Shared.Generated;

namespace HashSlinger.Shared.Generated
{
    public partial record SupertaskDto
    {
        public ICollection<SupertaskPretaskDto> SupertaskPretasks { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
    }
}