namespace RenCoryf.SmartShedule.DLA
{
    public abstract class Event
    {
        public Guid ID { get; set; }
        public Content Content { get; set; }
        public IntervalEvent Time { get; set; }
        public FramingEvent Frame { get; set; }
        public abstract TimeSpan[] timeNFrameCalculatingEvent(IntervalEvent time, FramingEvent frame);
    }
}
