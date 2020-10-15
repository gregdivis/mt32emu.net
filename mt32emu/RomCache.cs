using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;

namespace Mt32emu
{
    internal static partial class RomCache
    {
        private static readonly Dictionary<HashKey, byte[]> roms = new();

        public static RomData Load(Stream data, out HashKey hash)
        {
            if (data is null)
                throw new ArgumentNullException(nameof(data));

            if (!data.CanSeek)
            {
                using var temp = new MemoryStream();
                data.CopyTo(temp);
                temp.Position = 0;
                return Load(temp, out hash);
            }

            long pos = data.Position;
            using var sha1 = SHA1.Create();
            hash = new HashKey(sha1.ComputeHash(data));

            lock (roms)
            {
                if (roms.TryGetValue(hash, out var array))
                    return new RomData(array);

                data.Position = pos;

                array = GC.AllocateUninitializedArray<byte>((int)(data.Length - pos), pinned: true);
                data.Read(array);
                roms[hash] = array;

                return new RomData(array);
            }
        }
    }
}
