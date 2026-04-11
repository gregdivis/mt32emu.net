using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Mt32emu.Interop;

internal static partial class Libmt32emu
{
    private const string DllName = "libmt32emu";

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial uint mt32emu_get_library_version_int();

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: MarshalAs(UnmanagedType.LPUTF8Str)]
    public static partial string mt32emu_get_library_version_string();

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial uint mt32emu_get_stereo_output_samplerate(AnalogOutputMode analog_output_mode);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial AnalogOutputMode mt32emu_get_best_analog_output_mode(double target_samplerate);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe partial Mt32ContextSafeHandle mt32emu_create_context(ReportHandler* report_handler, nint instance_data);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void mt32emu_free_context(nint context);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe partial Mt32EmuReturnCode mt32emu_add_rom_data(Mt32ContextSafeHandle context, byte* data, IntPtr data_size, byte* sha1_digest);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial Mt32EmuReturnCode mt32emu_add_rom_file(Mt32ContextSafeHandle context, nint filename);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe partial void mt32emu_get_rom_info(Mt32ContextSafeHandle context, Mt32emu_rom_info* rom_info);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void mt32emu_set_partial_count(Mt32ContextSafeHandle context, uint partial_count);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void mt32emu_set_analog_output_mode(Mt32ContextSafeHandle context, AnalogOutputMode analog_output_mode);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void mt32emu_set_stereo_output_samplerate(Mt32ContextSafeHandle context, double samplerate);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void mt32emu_set_samplerate_conversion_quality(Mt32ContextSafeHandle context, SampleRateConversionQuality quality);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void mt32emu_select_renderer_type(Mt32ContextSafeHandle context, RendererType renderer_type);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial RendererType mt32emu_get_selected_renderer_type(Mt32ContextSafeHandle context);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial Mt32EmuReturnCode mt32emu_open_synth(Mt32ContextSafeHandle context);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void mt32emu_close_synth(Mt32ContextSafeHandle context);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static partial bool mt32emu_is_open(Mt32ContextSafeHandle context);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial uint mt32emu_get_actual_stereo_output_samplerate(Mt32ContextSafeHandle context);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial uint mt32emu_convert_output_to_synth_timestamp(Mt32ContextSafeHandle context, uint output_timestamp);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial uint mt32emu_convert_synth_to_output_timestamp(Mt32ContextSafeHandle context, uint synth_timestamp);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void mt32emu_flush_midi_queue(Mt32ContextSafeHandle context);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial uint mt32emu_set_midi_event_queue_size(Mt32ContextSafeHandle context, uint queue_size);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void mt32emu_configure_midi_event_queue_sysex_storage(Mt32ContextSafeHandle context, uint storage_buffer_size);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe partial void mt32emu_set_midi_receiver(Mt32ContextSafeHandle context, MidiReceiver* midi_receiver, IntPtr instance_data);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial uint mt32emu_get_internal_rendered_sample_count(Mt32ContextSafeHandle context);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe partial void mt32emu_parse_stream(Mt32ContextSafeHandle context, byte* stream, uint length);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe partial void mt32emu_parse_stream_at(Mt32ContextSafeHandle context, byte* stream, uint length, uint timestamp);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void mt32emu_play_short_message(Mt32ContextSafeHandle context, uint message);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void mt32emu_play_short_message_at(Mt32ContextSafeHandle context, uint message, uint timestamp);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial Mt32EmuReturnCode mt32emu_play_msg(Mt32ContextSafeHandle context, uint msg);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe partial Mt32EmuReturnCode mt32emu_play_sysex(Mt32ContextSafeHandle context, byte* sysex, uint len);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial Mt32EmuReturnCode mt32emu_play_msg_at(Mt32ContextSafeHandle context, uint msg, uint timestamp);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe partial Mt32EmuReturnCode mt32emu_play_sysex_at(Mt32ContextSafeHandle context, byte* sysex, uint len, uint timestamp);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void mt32emu_play_msg_now(Mt32ContextSafeHandle context, uint msg);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void mt32emu_play_msg_on_part(Mt32ContextSafeHandle context, byte part, byte code, byte note, byte velocity);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe partial void mt32emu_play_sysex_now(Mt32ContextSafeHandle context, byte* sysex, uint len);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe partial void mt32emu_write_sysex(Mt32ContextSafeHandle context, byte channel, byte* sysex, uint len);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void mt32emu_set_reverb_enabled(Mt32ContextSafeHandle context, [MarshalAs(UnmanagedType.Bool)] bool reverb_enabled);
    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static partial bool mt32emu_is_reverb_enabled(Mt32ContextSafeHandle context);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void mt32emu_set_reverb_overridden(Mt32ContextSafeHandle context, [MarshalAs(UnmanagedType.Bool)] bool reverb_overridden);
    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static partial bool mt32emu_is_reverb_overridden(Mt32ContextSafeHandle context);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void mt32emu_set_reverb_compatibility_mode(Mt32ContextSafeHandle context, [MarshalAs(UnmanagedType.Bool)] bool mt32_compatible_mode);
    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static partial bool mt32emu_is_mt32_reverb_compatibility_mode(Mt32ContextSafeHandle context);
    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static partial bool mt32emu_is_default_reverb_mt32_compatible(Mt32ContextSafeHandle context);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void mt32emu_preallocate_reverb_memory(Mt32ContextSafeHandle context, [MarshalAs(UnmanagedType.Bool)] bool enabled);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void mt32emu_set_dac_input_mode(Mt32ContextSafeHandle context, DacInputMode mode);
    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial DacInputMode mt32emu_get_dac_input_mode(Mt32ContextSafeHandle context);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void mt32emu_set_midi_delay_mode(Mt32ContextSafeHandle context, MidiDelayMode mode);
    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial MidiDelayMode mt32emu_get_midi_delay_mode(Mt32ContextSafeHandle context);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void mt32emu_set_output_gain(Mt32ContextSafeHandle context, float gain);
    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float mt32emu_get_output_gain(Mt32ContextSafeHandle context);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void mt32emu_set_reverb_output_gain(Mt32ContextSafeHandle context, float gain);
    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float mt32emu_get_reverb_output_gain(Mt32ContextSafeHandle context);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void mt32emu_set_reversed_stereo_enabled(Mt32ContextSafeHandle context, [MarshalAs(UnmanagedType.Bool)] bool enabled);
    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static partial bool mt32emu_is_reversed_stereo_enabled(Mt32ContextSafeHandle context);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void mt32emu_set_nice_amp_ramp_enabled(Mt32ContextSafeHandle context, [MarshalAs(UnmanagedType.Bool)] bool enabled);
    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static partial bool mt32emu_is_nice_amp_ramp_enabled(Mt32ContextSafeHandle context);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void mt32emu_set_nice_panning_enabled(Mt32ContextSafeHandle context, [MarshalAs(UnmanagedType.Bool)] bool enabled);
    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static partial bool mt32emu_is_nice_panning_enabled(Mt32ContextSafeHandle context);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void mt32emu_set_nice_partial_mixing_enabled(Mt32ContextSafeHandle context, [MarshalAs(UnmanagedType.Bool)] bool enabled);
    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static partial bool mt32emu_is_nice_partial_mixing_enabled(Mt32ContextSafeHandle context);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe partial void mt32emu_render_bit16s(Mt32ContextSafeHandle context, short* stream, uint len);
    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe partial void mt32emu_render_float(Mt32ContextSafeHandle context, float* stream, uint len);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void mt32emu_render_bit16s_streams(Mt32ContextSafeHandle context, nint streams, uint len);
    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void mt32emu_render_float_streams(Mt32ContextSafeHandle context, nint streams, uint len);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static partial bool mt32emu_has_active_partials(Mt32ContextSafeHandle context);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static partial bool mt32emu_is_active(Mt32ContextSafeHandle context);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial uint mt32emu_get_partial_count(Mt32ContextSafeHandle context);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial uint mt32emu_get_part_states(Mt32ContextSafeHandle context);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe partial void mt32emu_get_partial_states(Mt32ContextSafeHandle context, byte* partial_states);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe partial uint mt32emu_get_playing_notes(Mt32ContextSafeHandle context, byte part_number, byte* keys, byte* velocities);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe partial byte* mt32emu_get_patch_name(Mt32ContextSafeHandle context, byte part_number);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe partial void mt32emu_read_memory(Mt32ContextSafeHandle context, uint addr, uint len, byte* data);
}
