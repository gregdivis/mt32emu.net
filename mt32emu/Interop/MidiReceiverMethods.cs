using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Mt32emu.Interop
{
    internal static class MidiReceiverMethods
    {
        private static readonly MidiReceiver[] pinnedReceiver = GetPinnedArray();
        public static unsafe MidiReceiver* Pointer => (MidiReceiver*)Unsafe.AsPointer(ref pinnedReceiver[0]);

        [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
        private static uint GetVersionId(IntPtr receiver) => 0;
        [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
        private static void HandleShortMessage(IntPtr data, uint message) => GetHandler(data)?.HandleShortMessage(message);
        [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
        private static unsafe void HandleSysex(IntPtr data, byte* stream, uint length) => GetHandler(data)?.HandleSysex(new(stream, (int)length));
        [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
        private static void HandleSystemRealtimeMessage(IntPtr data, byte realtime) => GetHandler(data)?.HandleSystemRealtimeMessage(realtime);

        private static unsafe MidiReceiver[] GetPinnedArray()
        {
            var array = GC.AllocateArray<MidiReceiver>(1, pinned: true);
            array[0] = new MidiReceiver
            {
                getVersionID = &GetVersionId,
                handleShortMessage = &HandleShortMessage,
                handleSysex = &HandleSysex,
                handleSystemRealtimeMessage = &HandleSystemRealtimeMessage
            };

            return array;
        }

        private static IMt32MidiReceiver? GetHandler(IntPtr data) => GCHandle.FromIntPtr(data).Target as IMt32MidiReceiver;
    }
}
