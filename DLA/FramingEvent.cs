namespace RenCoryf.SmartShedule.DLA
{
    public class FramingEvent
    {
        public int NotificationTime { get; set; }
        public int AlarmSnoozing { get; set; }

        public FramingEvent(int notificationTime)
        {
            NotificationTime = notificationTime;
        }
        public FramingEvent(int notificationTime, int alarmSnoozing)
        {
            NotificationTime = notificationTime;
            AlarmSnoozing = alarmSnoozing;
        }

    }
}
