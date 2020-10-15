using System;
using System.Collections.Generic;
using System.Text;
using Mt32emu.Interop;

namespace Mt32emu
{
    public static class Mt32GlobalState
    {
        public static uint LibraryVersion => NativeMethods.mt32emu_get_library_version_int();
        public static string LibraryVersionText
        {
            get
            {
                unsafe
                {
                    return new string(NativeMethods.mt32emu_get_library_version_string());
                }
            }
        }

        public static uint GetStereoOutputSampleRate(AnalogOutputMode mode) => NativeMethods.mt32emu_get_stereo_output_samplerate(mode);
        public static AnalogOutputMode GetBestAnalogOutputMode(double targetSampleRate) => NativeMethods.mt32emu_get_best_analog_output_mode(targetSampleRate);
    }
}
