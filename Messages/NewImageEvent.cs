namespace EventAggregatorDemo;

public class NewImageEvent : EventArgs
{
    public long Data { get; set; }
    public string KameraName { get; set; }
}