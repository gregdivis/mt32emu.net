namespace Mt32emu
{
    /// <summary>
    /// Methods for emulating the connection between the LA32 and the DAC, which involves
    /// some hacks in the real devices for doubling the volume.
    /// </summary>
    public enum DacInputMode
    {
        /// <summary>
        /// Produces samples at double the volume, without tricks.
	    /// Nicer overdrive characteristics than the DAC hacks (it simply clips samples within range).
	    /// Higher quality than the real devices.
        /// </summary>
        Nice,
        /// <summary>
	    /// Produces samples that exactly match the bits output from the emulated LA32.
	    /// Nicer overdrive characteristics than the DAC hacks (it simply clips samples within range).
	    /// Much less likely to overdrive than any other mode.
	    /// Half the volume of any of the other modes.
	    /// Perfect for developers while debugging :)
        /// </summary>
        Pure,
        /// <summary>
	    /// Re-orders the LA32 output bits as in early generation MT-32s (according to Wikipedia).
	    /// Bit order at DAC (where each number represents the original LA32 output bit number, and XX means the bit is always low):
	    /// 15 13 12 11 10 09 08 07 06 05 04 03 02 01 00 XX
        /// </summary>
        Generation1,
        /// <summary>
	    /// Re-orders the LA32 output bits as in later generations (personally confirmed on my CM-32L - KG).
	    /// Bit order at DAC (where each number represents the original LA32 output bit number):
	    /// 15 13 12 11 10 09 08 07 06 05 04 03 02 01 00 14
        /// </summary>
        Generation2
    }
}
