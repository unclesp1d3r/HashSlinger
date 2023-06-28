using System;
using HashSlinger.Shared.Generated;

namespace HashSlinger.Shared.Generated
{
    public partial record BinaryHashDto
    {
        public string Essid { get; set; }
        public byte[] HashBytes { get; set; }
        public ChunkDto Chunk { get; set; }
        public HashlistDto Hashlist { get; set; }
        public int? ChunkId { get; set; }
        public ulong CrackPos { get; set; }
        public int HashlistId { get; set; }
        public int Id { get; set; }
        public bool IsCracked { get; set; }
        public string Plaintext { get; set; }
        public DateTime? TimeCracked { get; set; }
    }
}