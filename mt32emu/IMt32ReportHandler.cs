namespace Mt32emu
{
    public interface IMt32ReportHandler
    {
        void PrintDebug(string? message) { }
        void OnErrorControlROM();
        void OnErrorPCMROM();
        void ShowLCDMessage(string? message);
        void OnMIDIMessagePlayed();
        bool OnMIDIQueueOverflow() => false;
        void OnMIDISystemRealtime(byte systemRealtime);
        void OnDeviceReset();
        void OnDeviceReconfig();
        void OnNewReverbMode(byte mode);
        void OnNewReverbTime(byte time);
        void OnNewReverbLevel(byte level);
        void OnPolyStateChanged(byte partNumber);
        void OnProgramChanged(byte partNumber, string? soundGroupName, string? patchName);
    }
}
