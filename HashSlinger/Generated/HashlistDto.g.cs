using System.Collections.Generic;
using HashSlinger.Api.Generated;

namespace HashSlinger.Api.Generated
{
    public partial class HashlistDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Format { get; set; }
        public int HashTypeId { get; set; }
        public int HashCount { get; set; }
        public string? SaltSeparator { get; set; }
        public int Cracked { get; set; }
        public bool IsSecret { get; set; }
        public bool HexSalt { get; set; }
        public bool IsSalted { get; set; }
        public int AccessGroupId { get; set; }
        public string Notes { get; set; }
        public int BrainId { get; set; }
        public short BrainFeatures { get; set; }
        public bool IsArchived { get; set; }
        public AccessGroupDto AccessGroup { get; set; }
        public ICollection<HashBinaryDto> HashBinaries { get; set; }
        public HashTypeDto HashType { get; set; }
        public ICollection<HashDto> Hashes { get; set; }
        public ICollection<TaskWrapperDto> TaskWrappers { get; set; }
        public ICollection<ZapDto> Zaps { get; set; }
    }
}