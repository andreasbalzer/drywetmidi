using System;
using System.Runtime.InteropServices;
using System.Timers;

namespace Melanchall.DryWetMidi.Devices
{
    internal static class MidiTimerWinApi
    {
        #region Types

        [StructLayout(LayoutKind.Sequential)]
        public struct TIMECAPS
        {
            public uint wPeriodMin;
            public uint wPeriodMax;
        }

        public delegate void TimeProc(uint uID, uint uMsg, uint dwUser, uint dw1, uint dw2);

        #endregion

        #region Constants

        public const uint TIME_ONESHOT = 0;
        public const uint TIME_PERIODIC = 1;

        #endregion

        #region Methods

        private static System.Timers.Timer timer;

        public static uint timeGetDevCaps(ref TIMECAPS timeCaps, uint sizeTimeCaps)
        {
            timeCaps = new TIMECAPS()
            {
                wPeriodMin = 10,
                wPeriodMax = uint.MaxValue,
            };
            return MidiWinApi.MMSYSERR_NOERROR;
        }

        public static uint timeBeginPeriod(uint uPeriod)
        {
            return MidiWinApi.MMSYSERR_NOERROR;
        }

        public static uint timeEndPeriod(uint uPeriod)
        {
            return MidiWinApi.MMSYSERR_NOERROR;
        }

        public static uint timeSetEvent(uint uDelay, uint uResolution, TimeProc lpTimeProc, IntPtr dwUser, uint fuEvent)
        {
            if (timer != null)
            {
                return 1;
            }

            timer = new System.Timers.Timer(uResolution);
            timer.Elapsed += (Object source, ElapsedEventArgs e) => lpTimeProc(1, 0, 0, 0, 0);
            timer.Enabled = true;
            timer.AutoReset = true;
            timer.Interval = uResolution;
            timer.Start();

            return 1;
        }

        public static uint timeKillEvent(uint uTimerID)
        {
            if (timer != null)
            {
                timer.Stop();
                timer.Dispose();
            }

            timer = null;

            return MidiWinApi.MMSYSERR_NOERROR;
        }

        #endregion
    }
}
