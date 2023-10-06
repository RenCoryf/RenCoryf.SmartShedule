namespace RenCoryf.SmartShedule.DLA;

public class Shedule
{
    public string Title { get; set; }
    public DateOnly Date { get; set; }
    private List<Event> EventCollection { get; set; }
    public void eventAdding(Event currentEvent)//TODO repeatCycle for events
    {
       EventCollection.Add(currentEvent);
    }
    public Shedule(string title, DateOnly date)
    {
        Title = title;
        Date = date;
    }

}
