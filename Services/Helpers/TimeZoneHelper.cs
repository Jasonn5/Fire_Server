using System;
using System.Runtime.InteropServices;

namespace Services.Helpers
{
    public static class TimeZoneHelper
    {
        public static DateTime GetSaWesternStandardTime()
        {
            TimeZoneInfo saWesternStandardTime = null;
            var timeUtc = DateTime.UtcNow;

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                saWesternStandardTime = TimeZoneInfo.FindSystemTimeZoneById("SA Western Standard Time");
            }
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                saWesternStandardTime = TimeZoneInfo.FindSystemTimeZoneById("America/La_Paz");
            }

            return TimeZoneInfo.ConvertTimeFromUtc(timeUtc, saWesternStandardTime);
        }
    }
}
