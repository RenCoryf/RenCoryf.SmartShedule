namespace RenCoryf.SmartShedule.DLA
{
    public class AlarmEvent : Event
    {
        override public TimeSpan[] timeNFrameCalculatingEvent(IntervalEvent Time, FramingEvent Frame )
        {
            int sleepTime = ((24 - Time.StartTime.Hours) + Time.FinishTime.Hours) * 60 + (Time.StartTime.Minutes + Time.FinishTime.Minutes);
            int lastCycleTime = sleepTime % 115;
            int[] difference = { 0, 0, 0 };

            if (!(lastCycleTime >= 90 & lastCycleTime <= 115))
            {
                if (lastCycleTime <= Frame.AlarmSnoozing)
                {
                    difference[0] = lastCycleTime - Frame.AlarmSnoozing - 5 / 60;
                    difference[1] = lastCycleTime - Frame.AlarmSnoozing - 5 % 60;
                }
                else if (lastCycleTime >= 90 - Frame.AlarmSnoozing)
                {
                    difference[0] = lastCycleTime + Frame.AlarmSnoozing + 5 / 60;
                    difference[1] = lastCycleTime + Frame.AlarmSnoozing + 5 % 60;
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
            Time.FinishTime.Add(new TimeSpan(difference[0], difference[1], 0));
            TimeSpan[] timeNFrame = { Time.StartTime, Time.FinishTime, new TimeSpan(Frame.NotificationTime) };
            return timeNFrame;
        }

        public AlarmEvent(Content content, IntervalEvent time)
        {
            Content = content;
            Time = time;
        }
    }
}
