using Mt32emu.Interop;

namespace Mt32emu
{
    public sealed class Mt32RomInfo
    {
        internal Mt32RomInfo(in Mt32emu_rom_info native)
        {
            unsafe
            {
                this.ControlRomId = GetString(native.control_rom_id);
                this.ControlRomDescription = GetString(native.control_rom_description);
                this.ControlRomSHA1Digest = GetString(native.control_rom_sha1_digest);
                this.PcmRomId = GetString(native.pcm_rom_id);
                this.PcmRomDescription = GetString(native.pcm_rom_description);
                this.PcmRomSHA1Digest = GetString(native.pcm_rom_sha1_digest);
            }
        }

        public string? ControlRomId { get; }
        public string? ControlRomDescription { get; }
        public string? ControlRomSHA1Digest { get; }
        public string? PcmRomId { get; }
        public string? PcmRomDescription { get; }
        public string? PcmRomSHA1Digest { get; }

        private static unsafe string? GetString(sbyte* s) => s != null ? new string(s) : null;
    }
}
