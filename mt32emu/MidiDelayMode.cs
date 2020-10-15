namespace Mt32emu
{
    /// <summary>
    /// Methods for emulating the effective delay of incoming MIDI messages introduced by a MIDI interface.
    /// </summary>
    public enum MidiDelayMode
    {
        /// <summary>
        /// Process incoming MIDI events immediately.
        /// </summary>
        Immediate,
        /// <summary>
        /// Delay incoming short MIDI messages as if they where transferred via a MIDI cable to a real hardware unit and immediate sysex processing.
        /// This ensures more accurate timing of simultaneous NoteOn messages.
        /// </summary>
        DelayShortMessagesOnly,
        /// <summary>
        /// Delay all incoming MIDI events as if they where transferred via a MIDI cable to a real hardware unit.
        /// </summary>
        DelayAll
    }
}
