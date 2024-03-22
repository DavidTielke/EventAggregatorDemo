namespace EventAggregatorDemo;

public interface IEventAggregator
{
    void Subscribe<TEvent>(EventHandler method);
    void Publish(object sender, EventArgs message);
}