using System;

namespace BrawlStars.Logic
{
    public class Timer
    {
        public int EndSubTick;

        public void StartTimer(Time time, int seconds)
        {
            EndSubTick = time.SubTick + (int) Time.GetSecondsInTicks(seconds);
        }

        public void IncreaseTimer(int seconds)
        {
            EndSubTick += (int) Time.GetSecondsInTicks(seconds);
        }

        public void StopTimer()
        {
            EndSubTick = -1;
        }

        public void FastForward(int seconds)
        {
            EndSubTick -= (int) Time.GetSecondsInTicks(seconds);
        }

        public void FastForwardSubTicks(int subTick)
        {
            if (EndSubTick > 0) EndSubTick -= subTick;
        }

        public int GetRemainingSeconds(Time time)
        {
            var subTicks = EndSubTick - time.SubTick;
            return subTicks > 0 ? Math.Max((int) (16L * subTicks / 1000) + 1, 1) : 0;
        }

        public int GetRemainingMilliseconds(Time time)
        {
            var subTicks = EndSubTick - time.SubTick;
            return subTicks > 0 ? 16 * subTicks : 0;
        }

        public void AdjustSubTick(Time time)
        {
            EndSubTick -= time.SubTick;
            if (EndSubTick < 0) EndSubTick = 0;
        }
    }
}