using System;
using System.Runtime.InteropServices;

namespace Mt32emu.Interop
{
    [StructLayout(LayoutKind.Sequential)]
    internal unsafe struct ReportHandler
    {
        public delegate* unmanaged[Cdecl]<ReportHandler*, uint> getVersionId;
        public delegate* unmanaged[Cdecl]<IntPtr, byte*, void*, void> printDebug;
        public delegate* unmanaged[Cdecl]<IntPtr, void> onErrorControlROM;
        public delegate* unmanaged[Cdecl]<IntPtr, void> onErrorControlPCMROM;
        public delegate* unmanaged[Cdecl]<IntPtr, byte*, void> showLCDMessage;
        public delegate* unmanaged[Cdecl]<IntPtr, void> onMIDIMessagePlayed;
        public delegate* unmanaged[Cdecl]<IntPtr, uint> onMIDIQueueOverflow;
        public delegate* unmanaged[Cdecl]<IntPtr, byte, void> onMIDISystemRealtime;
        public delegate* unmanaged[Cdecl]<IntPtr, void> onDeviceReset;
        public delegate* unmanaged[Cdecl]<IntPtr, void> onDeviceReconfig;
        public delegate* unmanaged[Cdecl]<IntPtr, byte, void> onNewReverbMode;
        public delegate* unmanaged[Cdecl]<IntPtr, byte, void> onNewReverbTime;
        public delegate* unmanaged[Cdecl]<IntPtr, byte, void> onNewReverbLevel;
        public delegate* unmanaged[Cdecl]<IntPtr, byte, void> onPolyStateChanged;
        public delegate* unmanaged[Cdecl]<IntPtr, byte, byte*, byte*, void> onProgramChanged;
	}
}
