using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Mt32emu.Interop;

namespace Mt32emu
{
    /// <summary>
    /// Implements the context for rendering an MT-32 device.
    /// </summary>
    public sealed class Mt32Context : IDisposable
    {
        private readonly Mt32ContextSafeHandle handle;
        private AnalogOutputMode analogOutputMode;
        private readonly GCHandle reportHandlerHandle;
        private GCHandle midiReceiverHandle;
        private bool disposed;

        /// <summary>
        /// Initializes a new instance of the <see cref="Mt32Context"/> class.
        /// </summary>
        /// <param name="reportHandler">Optional callback interface to receive reporting information.</param>
        /// <exception cref="InvalidOperationException">Context could not be created.</exception>
        public Mt32Context(IMt32ReportHandler? reportHandler = null)
        {
            try
            {
                unsafe
                {
                    if (reportHandler != null)
                    {
                        this.reportHandlerHandle = GCHandle.Alloc(reportHandler);
                        this.handle = NativeMethods.mt32emu_create_context(ReportHandlerMethods.Pointer, GCHandle.ToIntPtr(this.reportHandlerHandle));
                    }
                    else
                    {
                        this.handle = NativeMethods.mt32emu_create_context(null, IntPtr.Zero);
                    }
                }

                if (this.handle.IsInvalid)
                    throw new InvalidOperationException("Invalid handle context returned.");
            }
            catch
            {
                if (this.reportHandlerHandle.IsAllocated)
                    this.reportHandlerHandle.Free();

                throw;
            }
        }

        /// <summary>
        /// Gets or sets the maximum number of partials playing simultaneously.
        /// </summary>
        public uint PartialCount
        {
            get => !this.disposed ? NativeMethods.mt32emu_get_partial_count(this.handle) : 0;
            set
            {
                this.CheckDisposed();
                NativeMethods.mt32emu_set_partial_count(this.handle, value);
            }
        }
        /// <summary>
        /// Gets or sets the context's analog output mode.
        /// </summary>
        /// <remarks>
        /// This will not have any effect if <see cref="OpenSynth"/> has already been called.
        /// </remarks>
        public AnalogOutputMode AnalogOutputMode
        {
            get => this.analogOutputMode;
            set
            {
                this.CheckDisposed();
                this.analogOutputMode = value;
                NativeMethods.mt32emu_set_analog_output_mode(this.handle, value);
            }
        }
        /// <summary>
        /// Gets or sets the selected wave generator and renderer.
        /// </summary>
        /// <remarks>
        /// This will not have any effect if <see cref="OpenSynth"/> has already been called.
        /// </remarks>
        public RendererType RendererType
        {
            get => !this.disposed ? NativeMethods.mt32emu_get_selected_renderer_type(this.handle) : default;
            set
            {
                this.CheckDisposed();
                NativeMethods.mt32emu_select_renderer_type(this.handle, value);
            }
        }
        /// <summary>
        /// Gets or sets a value indicating whether reverb effects are enabled.
        /// </summary>
        /// <remarks>
        /// This will not have any effect if <see cref="OpenSynth"/> has already been called.
        /// </remarks>
        public bool ReverbEnabled
        {
            get => !this.disposed ? NativeMethods.mt32emu_is_reverb_enabled(this.handle) : false;
            set
            {
                this.CheckDisposed();
                NativeMethods.mt32emu_set_reverb_enabled(this.handle, value);
            }
        }
        /// <summary>
        /// Gets or sets a value indicating whether the emulator is in old MT-32 reverb mode.
        /// </summary>
        /// <remarks>
        /// This will not have any effect if <see cref="OpenSynth"/> has already been called.
        /// </remarks>
        public bool ReverbCompatibilityMode
        {
            get => !this.disposed ? NativeMethods.mt32emu_is_mt32_reverb_compatibility_mode(this.handle) : false;
            set
            {
                this.CheckDisposed();
                NativeMethods.mt32emu_set_reverb_compatibility_mode(this.handle, value);
            }
        }
        /// <summary>
        /// Gets a value indicating whether default reverb compatibility mode is the old MT-32 compatibility mode.
        /// </summary>
        public bool DefaultReverbCompatibility => !this.disposed ? NativeMethods.mt32emu_is_default_reverb_mt32_compatible(this.handle) : false;
        /// <summary>
        /// Gets or sets the current DAC input mode.
        /// </summary>
        public DacInputMode DacInputMode
        {
            get => !this.disposed ? NativeMethods.mt32emu_get_dac_input_mode(this.handle) : default;
            set
            {
                this.CheckDisposed();
                NativeMethods.mt32emu_set_dac_input_mode(this.handle, value);
            }
        }
        /// <summary>
        /// Gets or sets the current MIDI delay mode.
        /// </summary>
        public MidiDelayMode MidiDelayMode
        {
            get => !this.disposed ? NativeMethods.mt32emu_get_midi_delay_mode(this.handle) : default;
            set
            {
                this.CheckDisposed();
                NativeMethods.mt32emu_set_midi_delay_mode(this.handle, value);
            }
        }
        /// <summary>
        /// Gets or sets the current output gain.
        /// </summary>
        public float OutputGain
        {
            get => !this.disposed ? NativeMethods.mt32emu_get_output_gain(this.handle) : 0;
            set
            {
                this.CheckDisposed();
                NativeMethods.mt32emu_set_output_gain(this.handle, value);
            }
        }
        /// <summary>
        /// Gets or sets the current reverb output gain.
        /// </summary>
        public float ReverbOutputGain
        {
            get => !this.disposed ? NativeMethods.mt32emu_get_reverb_output_gain(this.handle) : 0;
            set
            {
                this.CheckDisposed();
                NativeMethods.mt32emu_set_reverb_output_gain(this.handle, value);
            }
        }
        /// <summary>
        /// Gets or sets a value indicating whether stereo output data should be reversed.
        /// </summary>
        public bool ReverseStereo
        {
            get => !this.disposed ? NativeMethods.mt32emu_is_reversed_stereo_enabled(this.handle) : false;
            set
            {
                this.CheckDisposed();
                NativeMethods.mt32emu_set_reversed_stereo_enabled(this.handle, value);
            }
        }
        /// <summary>
        /// Gets or sets a value indicating whether nice amp ramp mode is enabled.
        /// </summary>
        public bool NiceAmpRampEnabled
        {
            get => !this.disposed ? NativeMethods.mt32emu_is_nice_amp_ramp_enabled(this.handle) : false;
            set
            {
                this.CheckDisposed();
                NativeMethods.mt32emu_set_nice_amp_ramp_enabled(this.handle, value);
            }
        }
        /// <summary>
        /// Gets or sets a value indicating whether nice panning is enabled.
        /// </summary>
        public bool NicePanningEnabled
        {
            get => !this.disposed ? NativeMethods.mt32emu_is_nice_panning_enabled(this.handle) : false;
            set
            {
                this.CheckDisposed();
                NativeMethods.mt32emu_set_nice_panning_enabled(this.handle, value);
            }
        }
        /// <summary>
        /// Gets or sets a value indicating whether nice partial mixing is enabled.
        /// </summary>
        public bool NicePartialMixingEnabled
        {
            get => !this.disposed ? NativeMethods.mt32emu_is_nice_partial_mixing_enabled(this.handle) : false;
            set
            {
                this.CheckDisposed();
                NativeMethods.mt32emu_set_nice_partial_mixing_enabled(this.handle, value);
            }
        }
        /// <summary>
        /// Gets a value indicating whether the device is open.
        /// </summary>
        /// <remarks>
        /// This will return <c>true</c> after <see cref="OpenSynth"/> has been called.
        /// </remarks>
        public bool IsOpen => !this.disposed ? NativeMethods.mt32emu_is_open(this.handle) : false;
        /// <summary>
        /// Gets a value indicating whether the device is actively being used.
        /// </summary>
        /// <remarks>
        /// This returns true if there are active partials or reverb is (somewhat unreliably) detected as being active.
        /// </remarks>
        public bool IsActive => !this.disposed ? NativeMethods.mt32emu_is_active(this.handle) : false;
        /// <summary>
        /// Gets the actual stereo output sample rate.
        /// </summary>
        public double ActualStereoOutputSampleRate => !this.disposed ? NativeMethods.mt32emu_get_actual_stereo_output_samplerate(this.handle) : 0;

        /// <summary>
        /// Sets the stereo output sample rate to use for rendering. 
        /// </summary>
        /// <param name="sampleRate">The sample rate.</param>
        public void SetSampleRate(double sampleRate)
        {
            this.CheckDisposed();
            NativeMethods.mt32emu_set_stereo_output_samplerate(this.handle, sampleRate);
        }
        /// <summary>
        /// Prepares the emulation context to receive MIDI messages and produce output audio data.
        /// </summary>
        /// <exception cref="Mt32EmuException">Device could not be opened.</exception>
        public void OpenSynth()
        {
            this.CheckDisposed();

            var res = NativeMethods.mt32emu_open_synth(this.handle);
            if (res != Mt32EmuReturnCode.OK)
                throw new Mt32EmuException(res);
        }
        /// <summary>
        /// Closes the emulation context freeing allocated resources.
        /// </summary>
        /// <remarks>
        /// Added ROMs remain unaffected and ready for reuse.
        /// </remarks>
        public void CloseSynth()
        {
            this.CheckDisposed();
            NativeMethods.mt32emu_close_synth(this.handle);
        }

        /// <summary>
        /// Loads a ROM file stored in the specified <see cref="Stream"/>.
        /// </summary>
        /// <param name="data"><see cref="Stream"/> containing ROM data.</param>
        /// <exception cref="ArgumentNullException"><paramref name="data"/> is null.</exception>
        /// <exception cref="Mt32EmuException">The ROM was not recognized.</exception>
        public void AddRom(Stream data)
        {
            this.CheckDisposed();
            if (data is null)
                throw new ArgumentNullException(nameof(data));

            var rom = RomCache.Load(data, out var hash);

            unsafe
            {
                byte* sha1 = stackalloc byte[40];
                var hashData = hash.Data;

                for (int i = 0; i < hashData.Length; i++)
                {
                    sha1[i * 2] = formatHexDigit(hashData[i] >> 4);
                    sha1[(i * 2) + 1] = formatHexDigit(hashData[i] & 0xF);
                }

                var res = NativeMethods.mt32emu_add_rom_data(this.handle, rom.Rom, new IntPtr(rom.Length), sha1);
                if (res < 0)
                    throw new Mt32EmuException(res);
            }

            static byte formatHexDigit(int nibble) => nibble < 10 ? (byte)(nibble + '0') : (byte)(nibble - 10 + 'a');
        }
        /// <summary>
        /// Loads a ROM stored in the specified file.
        /// </summary>
        /// <param name="fileName">Name of file containing ROM data.</param>
        /// <exception cref="ArgumentNullException"><paramref name="fileName"/> is null or empty.</exception>
        /// <exception cref="Mt32EmuException">The ROM was not recognized.</exception>
        public void AddRom(string fileName)
        {
            this.CheckDisposed();
            if (string.IsNullOrEmpty(fileName))
                throw new ArgumentNullException(nameof(fileName));

            using var stream = File.OpenRead(fileName);
            this.AddRom(stream);
        }
        /// <summary>
        /// Returns information about loaded ROMs.
        /// </summary>
        /// <returns>Information about loaded ROMs.</returns>
        public Mt32RomInfo GetRomInfo()
        {
            this.CheckDisposed();
            unsafe
            {
                Mt32emu_rom_info info = default;
                NativeMethods.mt32emu_get_rom_info(this.handle, &info);
                return new Mt32RomInfo(info);
            }
        }

        /// <summary>
        /// Processes all enqueued events immediately.
        /// </summary>
        public void FlushMidiQueue()
        {
            this.CheckDisposed();
            NativeMethods.mt32emu_flush_midi_queue(this.handle);
        }

        /// <summary>
        /// Installs a custom MIDI receiver object intended for receiving MIDI messages generated by MIDI stream parser.
        /// </summary>
        /// <param name="receiver">Interface to receiver MIDI events or <c>null</c> to disable sending events.</param>
        public void SetMidiReceiver(IMt32MidiReceiver? receiver)
        {
            this.CheckDisposed();
            unsafe
            {
                if (receiver == null)
                {
                    NativeMethods.mt32emu_set_midi_receiver(this.handle, null, IntPtr.Zero);

                    if (this.midiReceiverHandle.IsAllocated)
                    {
                        this.midiReceiverHandle.Free();
                        this.midiReceiverHandle = default;
                    }
                }
                else
                {
                    var handle = GCHandle.Alloc(receiver);
                    NativeMethods.mt32emu_set_midi_receiver(this.handle, MidiReceiverMethods.Pointer, GCHandle.ToIntPtr(handle));

                    if (this.midiReceiverHandle.IsAllocated)
                        this.midiReceiverHandle.Free();

                    this.midiReceiverHandle = handle;
                }
            }
        }

        /// <summary>
        /// Enqueues a single short MIDI message with full processing ASAP.
        /// </summary>
        /// <remarks>
        /// The short MIDI message may contain no status byte, the running status is used in this case.
        /// </remarks>
        /// <param name="message">The short message to enqueue.</param>
        public void PlayShortMessage(uint message)
        {
            this.CheckDisposed();
            NativeMethods.mt32emu_play_short_message(this.handle, message);
        }

        /// <summary>
        /// Enqueues a single short MIDI message to play at specified time with full processing.
        /// </summary>
        /// <remarks>
        /// The short MIDI message may contain no status byte, the running status is used in this case.
        /// </remarks>
        /// <param name="message">The short message to enqueue.</param>
        /// <param name="timestamp">Timestamp of when to play the message.</param>
        public void PlayShortMessage(uint message, uint timestamp)
        {
            this.CheckDisposed();
            NativeMethods.mt32emu_play_short_message_at(this.handle, message, timestamp);
        }

        /// <summary>
        /// Enqueues a single short MIDI message to be processed ASAP. The message must contain a status byte.
        /// </summary>
        /// <param name="message">The message to enqueue.</param>
        public void PlayMessage(uint message)
        {
            this.CheckDisposed();
            NativeMethods.mt32emu_play_msg(this.handle, message);
        }

        /// <summary>
        /// Enqueues a single short MIDI message to play at the specified time. The message must contain a status byte.
        /// </summary>
        /// <param name="message">The message to enqueue.</param>
        /// <param name="timestamp">Timestamp of when to play the message.</param>
        public void PlayMessage(uint message, uint timestamp)
        {
            this.CheckDisposed();
            NativeMethods.mt32emu_play_msg_at(this.handle, message, timestamp);
        }

        /// <summary>
        /// Enqueues a single well formed System Exclusive MIDI message to be processed ASAP.
        /// </summary>
        /// <param name="data">The System Exclusive MIDI message to play.</param>
        public void PlaySysex(ReadOnlySpan<byte> data)
        {
            this.CheckDisposed();
            unsafe
            {
                fixed (byte* ptr = data)
                {
                    NativeMethods.mt32emu_play_sysex(this.handle, ptr, (uint)data.Length);
                }
            }
        }
        /// <summary>
        /// Enqueues a single well formed System Exclusive MIDI message to be processed ASAP.
        /// </summary>
        /// <param name="data">The System Exclusive MIDI message to play.</param>
        /// <param name="timestamp">Timestamp of when to play the message.</param>
        public void PlaySysex(ReadOnlySpan<byte> data, uint timestamp)
        {
            this.CheckDisposed();
            unsafe
            {
                fixed (byte* ptr = data)
                {
                    NativeMethods.mt32emu_play_sysex_at(this.handle, ptr, (uint)data.Length, timestamp);
                }
            }
        }

        /// <summary>
        /// Renders samples to the specified output stream as if they were sampled at the analog stereo output at the desired sample rate.
        /// </summary>
        /// <param name="stream">Buffer into which 16-bit PCM stereo sample data is written.</param>
        public void Render(Span<short> stream)
        {
            this.CheckDisposed();
            unsafe
            {
                fixed (short* ptr = stream)
                {
                    NativeMethods.mt32emu_render_bit16s(this.handle, ptr, (uint)stream.Length / 2u);
                }
            }
        }
        /// <summary>
        /// Renders samples to the specified output stream as if they were sampled at the analog stereo output at the desired sample rate.
        /// </summary>
        /// <param name="stream">Buffer into which 32-bit IEEE floating point stereo sample data is written.</param>
        public void Render(Span<float> stream)
        {
            this.CheckDisposed();
            unsafe
            {
                fixed (float* ptr = stream)
                {
                    NativeMethods.mt32emu_render_float(this.handle, ptr, (uint)stream.Length / 2u);
                }
            }
        }

        /// <summary>
        /// Returns current states of all the parts as a bit set.
        /// </summary>
        /// <remarks>
        /// The least significant bit corresponds to the state of part 1,
        /// total of 9 bits hold the states of all the parts.If the returned bit for a
        /// part is set, there is at least one active non-releasing partial playing on
        /// this part.This info is useful in emulating behaviour of LCD display of the hardware units.
        /// </remarks>
        /// <returns>
        /// Bit set of all part states.
        /// </returns>
        public uint GetPartStates()
        {
            this.CheckDisposed();
            return NativeMethods.mt32emu_get_part_states(this.handle);
        }

        /// <summary>
        /// Fills in current states of all the partials into the buffer provided.
        /// </summary>
        /// <param name="partialStates">Buffer into which partial states are written. The buffer must be large enough to accomodate all partials.</param>
        /// <exception cref="ArgumentException"><paramref name="partialStates"/> is not long enough.</exception>
        public void GetPartialStates(Span<byte> partialStates)
        {
            this.CheckDisposed();

            int partials = (int)this.PartialCount;
            if (partialStates.Length < partials)
                throw new ArgumentException("Insufficient length.");

            unsafe
            {
                fixed (byte* ptr = partialStates)
                {
                    NativeMethods.mt32emu_get_partial_states(this.handle, ptr);
                }
            }
        }
        /// <summary>
        /// Fills in information about currently playing notes on the specified part into the arrays provided.
        /// </summary>
        /// <param name="partNumber">The part number.</param>
        /// <param name="keys">Buffer to write keys.</param>
        /// <param name="velocities">Buffer to write velocities.</param>
        /// <returns>Number of currently playing notes on the specified parts.</returns>
        /// <exception cref="ArgumentException"><paramref name="keys"/> or <paramref name="velocities"/> is not long enough.</exception>
        public uint GetPlayingNotes(byte partNumber, Span<byte> keys, Span<byte> velocities)
        {
            this.CheckDisposed();

            int partials = (int)this.PartialCount;
            if (keys.Length < partials || velocities.Length < partials)
                throw new ArgumentException("Insufficient length.");

            unsafe
            {
                fixed (byte* keysPtr = keys)
                fixed (byte* velocitiesPtr = velocities)
                {
                    return NativeMethods.mt32emu_get_playing_notes(this.handle, partNumber, keysPtr, velocitiesPtr);
                }
            }
        }
        /// <summary>
        /// Returns name of the patch set on the specified part.
        /// </summary>
        /// <param name="partNumber">The part number.</param>
        /// <returns>The name of the patch set.</returns>
        public string? GetPatchName(byte partNumber)
        {
            this.CheckDisposed();

            unsafe
            {
                var ptr = NativeMethods.mt32emu_get_patch_name(this.handle, partNumber);
                return ReportHandlerMethods.GetString(ptr);
            }
        }
        /// <summary>
        /// Stores internal state of emulated synth into the specified buffer (as it would be acquired from hardware).
        /// </summary>
        /// <param name="address">Address to read from.</param>
        /// <param name="buffer">Buffer to fill with data.</param>
        public void ReadMemory(uint address, Span<byte> buffer)
        {
            this.CheckDisposed();

            unsafe
            {
                fixed (byte* ptr = buffer)
                {
                    NativeMethods.mt32emu_read_memory(this.handle, address, (uint)buffer.Length, ptr);
                }
            }
        }

        /// <summary>
        /// Closes the device and releases resources used for emulation.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    this.handle.Dispose();
                }
                else
                {
                    // explicitly dispose this even here to make sure it gets released before the report handler
                    var handle = this.handle;
                    if (!handle.IsClosed && !handle.IsInvalid)
                        handle.Dispose();
                }

                if (this.reportHandlerHandle.IsAllocated)
                    this.reportHandlerHandle.Free();

                if (this.midiReceiverHandle.IsAllocated)
                    this.midiReceiverHandle.Free();

                this.disposed = true;
            }
        }

        private void CheckDisposed()
        {
            if (this.disposed)
                throwException();

            [MethodImpl(MethodImplOptions.NoInlining)]
            static void throwException() => throw new ObjectDisposedException(nameof(Mt32Context));
        }
    }
}
