using System.Runtime.InteropServices;

namespace Mt32emu.Interop
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct Mt32emu_rom_info
    {
        public unsafe sbyte* control_rom_id;
        public unsafe sbyte* control_rom_description;
        public unsafe sbyte* control_rom_sha1_digest;
        public unsafe sbyte* pcm_rom_id;
        public unsafe sbyte* pcm_rom_description;
        public unsafe sbyte* pcm_rom_sha1_digest;
    }
}
