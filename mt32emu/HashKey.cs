using System;
using System.Linq;

namespace Mt32emu
{
    internal readonly struct HashKey : IEquatable<HashKey>
    {
        private readonly byte[] hash;

        public HashKey(byte[] hash) => this.hash = hash;

        public ReadOnlySpan<byte> Data => this.hash;

        public bool Equals(HashKey other)
        {
            if (ReferenceEquals(this.hash, other.hash))
                return true;
            if (this.hash is null || other.hash is null)
                return false;

            return this.hash.AsSpan().SequenceEqual(other.hash.AsSpan());
        }
        public override bool Equals(object? obj) => obj is HashKey k && this.Equals(k);
        public override int GetHashCode()
        {
            if (this.hash is null || this.hash.Length < 4)
                return 0;

            return BitConverter.ToInt32(this.hash, 0);
        }
        public override string ToString()
        {
            if (this.hash == null)
                return string.Empty;

            return string.Join(string.Empty, this.hash.Select(b => b.ToString("x2")));
        }
    }
}
