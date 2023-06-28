using System.Collections.Generic;
using HashSlinger.Shared.Generated;

namespace HashSlinger.Shared.Generated
{
    public partial record HashlistDto
    {
        public AccessGroupDto AccessGroup { get; set; }
        public ICollection<BinaryHashDto> BinaryHashes { get; set; }
        public ICollection<HashDto> Hashes { get; set; }
        public HashTypeDto HashType { get; set; }
        public ICollection<TaskWrapperDto> TaskWrappers { get; set; }
        public ICollection<ZapDto> Zaps { get; set; }
        public int AccessGroupId { get; set; }
        public short BrainFeatures { get; set; }
        public int BrainId { get; set; }
        public int Cracked { get; set; }
        public string Format { get; set; }
        public int HashCount { get; set; }
        public bool HexSalt { get; set; }
        public int Id { get; set; }
        public bool IsArchived { get; set; }
        public bool IsSalted { get; set; }
        public bool IsSecret { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        public string? SaltSeparator { get; set; }
    }
}