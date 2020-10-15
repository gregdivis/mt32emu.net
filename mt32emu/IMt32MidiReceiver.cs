using System;

namespace Mt32emu
{
    public interface IMt32MidiReceiver
    {
        void HandleShortMessage(uint message);
        void HandleSysex(ReadOnlySpan<byte> stream);
        void HandleSystemRealtimeMessage(byte realtime);
    }
}
