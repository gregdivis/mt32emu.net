using System;

namespace Mt32emu
{
    /// <summary>
    /// Represents an error that occurred with the MT-32 emulator.
    /// </summary>
    public class Mt32EmuException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Mt32EmuException"/> class.
        /// </summary>
        /// <param name="returnCode">Return code from the native library.</param>
        public Mt32EmuException(Mt32EmuReturnCode returnCode) => this.ReturnCode = returnCode;

        /// <summary>
        /// Gets the native return code.
        /// </summary>
        public Mt32EmuReturnCode ReturnCode { get; }
        public override string Message => this.ReturnCode switch
        {
            Mt32EmuReturnCode.RomNotIdentified => "ROM not identified.",
            Mt32EmuReturnCode.FileNotFound => "File not found.",
            Mt32EmuReturnCode.FileNotLoaded => "ROM not loaded.",
            Mt32EmuReturnCode.MissingRoms => "Required ROMs have not been loaded.",
            Mt32EmuReturnCode.NotOpened => "Device is not open.",
            Mt32EmuReturnCode.QueueFull => "Queue is full.",
            _ => "Unknown error."
        };
    }
}
