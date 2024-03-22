namespace EventAggregatorDemo;

class Button
{
    public event EventHandler<ButtonEventArgs> Clicked;
        
    public void Click()
    {
        Clicked?.Invoke(this, new ButtonEventArgs() {DateTime = DateTime.Now});
    }
}