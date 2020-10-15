using System;
using System.Runtime.InteropServices;

namespace Mt32emu.Interop
{
    [StructLayout(LayoutKind.Sequential)]
    internal unsafe struct MidiReceiver
    {
        public delegate* unmanaged[Cdecl] <IntPtr, uint> getVersionID;
        public delegate* unmanaged[Cdecl]<IntPtr, uint, void> handleShortMessage;
        public delegate* unmanaged[Cdecl]<IntPtr, byte*, uint, void> handleSysex;
        public delegate* unmanaged[Cdecl]<IntPtr, byte, void> handleSystemRealtimeMessage;
    }
}
