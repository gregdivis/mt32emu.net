using System.Runtime.CompilerServices;

namespace Mt32emu
{
    internal readonly struct RomData
    {
        private readonly byte[] pinnedData;

        public RomData(byte[] pinnedData) => this.pinnedData = pinnedData;

        public unsafe byte* Rom => this.pinnedData != null ? (byte*)Unsafe.AsPointer(ref this.pinnedData[0]) : null;
        public uint Length => (uint)(this.pinnedData?.Length).GetValueOrDefault();
    }
}
