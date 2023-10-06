namespace RenCoryf.SmartShedule.DLA
{
    public class IntervalEvent
    {
        public TimeSpan StartTime;
        public TimeSpan FinishTime;
        public IntervalEvent(int[] startTime, int[] finishTime)
        {
            StartTime = new TimeSpan(startTime[0], startTime[1], startTime[2]);
            FinishTime = new TimeSpan(finishTime[0], finishTime[1], finishTime[2]);
        }
    }
}
