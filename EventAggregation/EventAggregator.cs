namespace EventAggregatorDemo;

public class EventAggregator : IEventAggregator
{
    private Dictionary<Type, List<EventHandler>> _handlers = new Dictionary<Type, List<EventHandler>>();

    public void Subscribe<TEvent>(EventHandler method)
    {
        var messageType = typeof(TEvent);
        var keyAlreadyExist = _handlers.ContainsKey(messageType);
        if (keyAlreadyExist)
        {
            var handlerList = _handlers[messageType];
            handlerList.Add(method);
        }
        else
        {
            var handlerList = new List<EventHandler>();
            handlerList.Add(method);
            _handlers.Add(messageType, handlerList);
        }
    }

    public void Publish(object sender, EventArgs message)
    {
        var messageType = message.GetType();
        var handlerExist = _handlers.ContainsKey(messageType);
        if (!handlerExist) return;

        var handlerList = _handlers[messageType];
        foreach (var handler in handlerList)
        {
            handler.Invoke(sender, message);
        }
    }
}