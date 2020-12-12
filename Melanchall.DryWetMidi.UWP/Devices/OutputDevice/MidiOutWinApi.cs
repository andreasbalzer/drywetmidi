using System;
using System.Runtime.InteropServices;
using System.Text;
using Windows.Devices.Enumeration;
using Windows.Devices.Midi;

namespace Melanchall.DryWetMidi.Devices
{
    internal static class MidiOutWinApi
    {
        #region Types

        [StructLayout(LayoutKind.Sequential)]
        public struct MIDIOUTCAPS
        {
            public ushort wMid;
            public ushort wPid;
            public uint vDriverVersion;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
            public string szPname;
            public ushort wTechnology;
            public ushort wVoices;
            public ushort wNotes;
            public ushort wChannelMask;
            public uint dwSupport;
        }

        [Flags]
        public enum MIDICAPS : uint
        {
            MIDICAPS_VOLUME = 1,
            MIDICAPS_LRVOLUME = 2,
            MIDICAPS_CACHE = 4,
            MIDICAPS_STREAM = 8
        }

        #endregion

        #region Methods

        public static uint midiOutGetDevCaps(IntPtr uDeviceID, ref MIDIOUTCAPS lpMidiOutCaps, uint cbMidiOutCaps)
        {
            return MidiWinApi.MMSYSERR_NOERROR;
        }

        public static uint midiOutGetErrorText(uint mmrError, StringBuilder pszText, uint cchText)
        {
            return MidiWinApi.MMSYSERR_NOERROR;
        }

        public static uint midiOutGetNumDevs()
        {
            string midiOutportQueryString = MidiOutPort.GetDeviceSelector();
            DeviceInformationCollection midiOutputDevices = DeviceInformation.FindAllAsync(midiOutportQueryString).Result;
            return midiOutputDevices.Count;
            return MidiWinApi.MMSYSERR_NOERROR;
        }

        public static uint midiOutOpen(out IntPtr lphmo, int uDeviceID, MidiWinApi.MidiMessageCallback dwCallback, IntPtr dwInstance, uint dwFlags)
        {
            lphmo = new IntPtr(0);
            return MidiWinApi.MMSYSERR_NOERROR;
        }

        public static uint midiOutClose(IntPtr hmo)
        {
            return MidiWinApi.MMSYSERR_NOERROR;
        }

        public static uint midiOutShortMsg(IntPtr hMidiOut, uint dwMsg)
        {
            return MidiWinApi.MMSYSERR_NOERROR;
        }

        public static uint midiOutGetVolume(IntPtr hmo, ref uint lpdwVolume)
        {
            return MidiWinApi.MMSYSERR_NOERROR;
        }

        public static uint midiOutSetVolume(IntPtr hmo, uint dwVolume)
        {
            return MidiWinApi.MMSYSERR_NOERROR;
        }

        public static uint midiOutPrepareHeader(IntPtr hmo, IntPtr lpMidiOutHdr, int cbMidiOutHdr)
        {
            return MidiWinApi.MMSYSERR_NOERROR;
        }

        public static uint midiOutUnprepareHeader(IntPtr hmo, IntPtr lpMidiOutHdr, int cbMidiOutHdr)
        {
            return MidiWinApi.MMSYSERR_NOERROR;
        }

        public static uint midiOutLongMsg(IntPtr hmo, IntPtr lpMidiOutHdr, int cbMidiOutHdr)
        {
            return MidiWinApi.MMSYSERR_NOERROR;
        }

        #endregion
    }
}
