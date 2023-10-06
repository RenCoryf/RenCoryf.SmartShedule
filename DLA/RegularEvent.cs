namespace RenCoryf.SmartShedule.DLA
{
    public class RegularEvent : Event
    {
        override public TimeSpan[] timeNFrameCalculatingEvent (IntervalEvent Time, FramingEvent Frame)
        {
            TimeSpan[] timeNFrame = { Time.StartTime, Time.FinishTime, new TimeSpan(Frame.NotificationTime) };
            return timeNFrame;
        }
        public RegularEvent(Content content, IntervalEvent time)
        {
            Content = content;
            Time = time;
        }
    }
}
