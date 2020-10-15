namespace Mt32emu
{
    /// <summary>
    /// Methods for emulating the effects of analogue circuits of real hardware units on the output signal.
    /// </summary>
    public enum AnalogOutputMode
    {
        /// <summary>
        /// Only digital path is emulated. The output samples correspond to the digital signal at the DAC entrance.
        /// </summary>
        DigitalOnly,
        /// <summary>
        /// Coarse emulation of LPF circuit. High frequencies are boosted, sample rate remains unchanged.
        /// </summary>
        Coarse,
        /// <summary>
        /// Finer emulation of LPF circuit. Output signal is upsampled to 48 kHz to allow emulation of audible mirror spectra above 16 kHz,
        /// which is passed through the LPF circuit without significant attenuation.
        /// </summary>
        Accurate,
        /// <summary>
        /// Same as <see cref="Accurate"/> mode but the output signal is 2x oversampled, i.e. the output sample rate is 96 kHz.
        /// This makes subsequent resampling easier. Besides, due to nonlinear passband of the LPF emulated, it takes fewer number of MACs
        /// compared to a regular LPF FIR implementations.
        /// </summary>
        Oversampled
    }
}
