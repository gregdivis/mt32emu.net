namespace Mt32emu
{
    /// <summary>
    /// Specifies native error/return codes.
    /// </summary>
    public enum Mt32EmuReturnCode
    {
        /// <summary>
        /// No error.
        /// </summary>
        OK = 0,
        /// <summary>
        /// No error. Control ROM loaded successfully.
        /// </summary>
        AddedControlRom = 1,
        /// <summary>
        /// No error. PCM ROM loaded successfully.
        /// </summary>
        AddedPcmRom = 2,

        /// <summary>
        /// Specified ROM was not identified.
        /// </summary>
        RomNotIdentified = -1,
        /// <summary>
        /// ROM file not found.
        /// </summary>
        FileNotFound = -2,
        /// <summary>
        /// ROM file not loaded.
        /// </summary>
        FileNotLoaded = -3,
        /// <summary>
        /// ROMs have not been loaded
        /// </summary>
        MissingRoms = -4,
        /// <summary>
        /// Device is not open.
        /// </summary>
        NotOpened = -5,
        /// <summary>
        /// Device queue is full.
        /// </summary>
        QueueFull = -6,

        /// <summary>
        /// Undefined error occurred.
        /// </summary>
        Failed = -100
    }
}
