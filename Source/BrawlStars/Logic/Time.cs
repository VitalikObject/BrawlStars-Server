using System;

namespace BrawlStars.Logic
{
    public class Time
    {
        public int SubTick { get; set; }

        public int TotalMilliseconds => 16 * SubTick;

        public int TotalSeconds => SubTick > 0 ? Math.Max((int) (ulong) (16L * SubTick / 1000) + 1, 1) : 0;

        public static long GetSecondsInTicks(int seconds)
        {
            return (long) (seconds * 62.5);
        }
    }
}