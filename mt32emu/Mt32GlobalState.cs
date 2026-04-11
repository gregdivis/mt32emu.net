using static Mt32emu.Interop.Libmt32emu;

namespace Mt32emu;

public static class Mt32GlobalState
{
    public static uint LibraryVersion => mt32emu_get_library_version_int();
    public static string LibraryVersionText => mt32emu_get_library_version_string();

    public static uint GetStereoOutputSampleRate(AnalogOutputMode mode) => mt32emu_get_stereo_output_samplerate(mode);
    public static AnalogOutputMode GetBestAnalogOutputMode(double targetSampleRate) => mt32emu_get_best_analog_output_mode(targetSampleRate);
}
