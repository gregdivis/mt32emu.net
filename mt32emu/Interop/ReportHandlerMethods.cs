using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace Mt32emu.Interop
{
    internal static class ReportHandlerMethods
    {
        private static readonly ReportHandler[] pinnedHandler = GetPinnedArray();
        public static unsafe ReportHandler* Pointer => (ReportHandler*)Unsafe.AsPointer(ref pinnedHandler[0]);

        internal static unsafe string? GetString(byte* bytes)
        {
            if (bytes == null)
                return null;

            int length = 500;

            for (int i = 0; i < 500; i++)
            {
                if (bytes[i] == 0)
                {
                    length = i;
                    break;
                }
            }

            return Encoding.UTF8.GetString(bytes, length);
        }

        [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
        private static unsafe uint GetVersionId(ReportHandler* handler) => 0;
        [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
        private static unsafe void PrintDebug(IntPtr data, byte* fmt, void* list) => GetHandler(data)?.PrintDebug(GetString(fmt));
        [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
        private static void OnErrorControlROM(IntPtr data) => GetHandler(data)?.OnErrorControlROM();
        [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
        private static void OnErrorPCMROM(IntPtr data) => GetHandler(data)?.OnErrorPCMROM();
        [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
        private static unsafe void ShowLCDMessage(IntPtr data, byte* message) => GetHandler(data)?.ShowLCDMessage(GetString(message));
        [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
        private static void OnMIDIMessagePlayed(IntPtr data) => GetHandler(data)?.OnMIDIMessagePlayed();
        [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
        private static uint OnMIDIQueueOverflow(IntPtr data) => (GetHandler(data)?.OnMIDIQueueOverflow()).GetValueOrDefault() ? 1u : 0;
        [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
        private static void OnMIDISystemRealtime(IntPtr data, byte system_realtime) => GetHandler(data)?.OnMIDISystemRealtime(system_realtime);
        [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
        private static void OnDeviceReset(IntPtr data) => GetHandler(data)?.OnDeviceReset();
        [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
        private static void OnDeviceReconfig(IntPtr data) => GetHandler(data)?.OnDeviceReconfig();
        [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
        private static void OnNewReverbMode(IntPtr data, byte mode) => GetHandler(data)?.OnNewReverbMode(mode);
        [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
        private static void OnNewReverbTime(IntPtr data, byte time) => GetHandler(data)?.OnNewReverbTime(time);
        [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
        private static void OnNewReverbLevel(IntPtr data, byte level) => GetHandler(data)?.OnNewReverbLevel(level);
        [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
        private static void OnPolyStateChanged(IntPtr data, byte part_num) => GetHandler(data)?.OnPolyStateChanged(part_num);
        [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
        private static unsafe void OnProgramChanged(IntPtr data, byte part_num, byte* sound_group_name, byte* patch_name) => GetHandler(data)?.OnProgramChanged(part_num, GetString(sound_group_name), GetString(patch_name));

        private static unsafe ReportHandler[] GetPinnedArray()
        {
            var array = GC.AllocateArray<ReportHandler>(1, pinned: true);
            array[0] = new ReportHandler
            {
                getVersionId = &GetVersionId,
                printDebug = &PrintDebug,
                onErrorControlROM = &OnErrorControlROM,
                onErrorControlPCMROM = &OnErrorPCMROM,
                showLCDMessage = &ShowLCDMessage,
                onMIDIMessagePlayed = &OnMIDIMessagePlayed,
                onMIDIQueueOverflow = &OnMIDIQueueOverflow,
                onMIDISystemRealtime = &OnMIDISystemRealtime,
                onDeviceReset = &OnDeviceReset,
                onDeviceReconfig = &OnDeviceReconfig,
                onNewReverbMode = &OnNewReverbMode,
                onNewReverbTime = &OnNewReverbTime,
                onNewReverbLevel = &OnNewReverbLevel,
                onPolyStateChanged = &OnPolyStateChanged,
                onProgramChanged = &OnProgramChanged
            };

            return array;
        }

        private static IMt32ReportHandler? GetHandler(IntPtr data) => GCHandle.FromIntPtr(data).Target as IMt32ReportHandler;
    }
}
