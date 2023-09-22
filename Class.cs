namespace RenCoryf.SmartShedule
{
    public abstract class Event
    {
        public abstract TimeSpan[] IntervalCalculating(int[] time1, int[] time2, int range);
    }
    public class RegularEvent : Event
    {
        public override TimeSpan[] IntervalCalculating(int[] time1, int[] time2, int rangeM)
        {
            TimeSpan startTime = new TimeSpan(time1[0], time1[1], time1[2]);
            TimeSpan finishTime = new TimeSpan(time2[0], time2[1], time2[2]);
            int rangeH = 0;
            if (rangeM >= 60)
            {
                rangeH = rangeM / 60;
                rangeM -= rangeH * 60;
            }
            TimeSpan reminderTime = new TimeSpan(time1[0], time1[1]+rangeM, time1[2]+rangeH);
            TimeSpan[] interval = { startTime, finishTime, reminderTime };
            return interval;
        }
    }
    public class AlarmEvent : Event
        {
        public override TimeSpan[] IntervalCalculating(int[] time1, int[] time2, int range)
        {
            return new TimeSpan[0];
        }
    }
}
