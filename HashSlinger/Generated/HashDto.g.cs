using System;
using HashSlinger.Api.Generated;

namespace HashSlinger.Api.Generated
{
    public partial record HashDto
    {
        public ChunkDto? Chunk { get; set; }
        public HashlistDto Hashlist { get; set; }
        public int? ChunkId { get; set; }
        public ulong CrackPos { get; set; }
        public int HashlistId { get; set; }
        public string HashValue { get; set; }
        public int Id { get; set; }
        public bool IsCracked { get; set; }
        public string? Plaintext { get; set; }
        public string? Salt { get; set; }
        public DateTime? TimeCracked { get; set; }
    }
}