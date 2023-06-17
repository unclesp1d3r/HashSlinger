using System;
using HashSlinger.Api.Generated;

namespace HashSlinger.Api.Generated
{
    public partial class HashBinaryDto
    {
        public ChunkDto? Chunk { get; set; }
        public HashlistDto Hashlist { get; set; }
        public int? ChunkId { get; set; }
        public ulong CrackPos { get; set; }
        public string Essid { get; set; }
        public string Hash { get; set; }
        public int HashlistId { get; set; }
        public int Id { get; set; }
        public bool IsCracked { get; set; }
        public string? Plaintext { get; set; }
        public DateTime? TimeCracked { get; set; }
    }
}