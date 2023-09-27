namespace RenCoryf.SmartShedule
{
    public abstract class Event<T>
    {

        public int[] time1 { get; set; }
        public int[] time2 { get; set; }
        public T range { get; set; }
        public abstract TimeSpan[] IntervalCalculating(int[] time1, int[] time2, T range);
    }
    public class RegularEvent : Event<int>
    {
        override public TimeSpan[] IntervalCalculating(int[] time1, int[] time2, int rangeM)
        {
            TimeSpan startTime = new TimeSpan(time1[0], time1[1], time1[2]);
            TimeSpan finishTime = new TimeSpan(time2[0], time2[1], time2[2]);
            int rangeH=0;
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
    public class AlarmEvent : Event<int[]>
        {
        override public TimeSpan[] IntervalCalculating(int[] time1, int[] time2, int[] range)
        {
            TimeSpan startTime = new TimeSpan(time1[0], time1[1], time1[2]);
            //TimeSpan finishTime = new TimeSpan(time2[0], time2[1], time2[2]);
            int sleepTime = ((24 - time1[0]) + time2[0])*60 + (time1[1] + time2[1]);
            int lastCycleTime = sleepTime%115;
            TimeSpan finishTime = new TimeSpan(time2[0], time2[1], time2[2]);
            int[] difference = { 0, 0, 0 };

            if (!(lastCycleTime >= 90 & lastCycleTime <= 115))
                {
                if (lastCycleTime <= range[1])
                {
                    difference[0] = lastCycleTime - range[1] - 5 / 60;
                    difference[1] = lastCycleTime - range[1] - 5 % 60;
                }
                else if (lastCycleTime >= 90 - range[1])
                {
                    difference[0] = lastCycleTime + range[1] + 5 / 60;
                    difference[1] = lastCycleTime + range[1] + 5 % 60;
                }
                else if (lastCycleTime < 45)
                {
                    throw new Exception("not optionanl time choice");
                }
                else
                {
                    throw new Exception("sth went wrong with alarm");
                }
                
            }
                finishTime.Add(new TimeSpan(difference[0], difference[1],0));
            int rangeH = 0;
            if (range[0] >= 60)
            {
                rangeH = range[0] / 60;
                range[0] -= rangeH * 60;
            }
            TimeSpan reminderTime = new TimeSpan(time1[0], time1[1] + range[0], time1[2] + rangeH);
            TimeSpan[] interval = { startTime, finishTime, reminderTime };
            return interval;
        }
    }
}
