namespace EventAggregatorDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // CrossCutting
            var eventAggregator = new EventAggregator();

            // --- Logic
            // ----> Komp 1
            eventAggregator.Subscribe<NewImageEvent>(HandleNewEvent);
            // ----> Komp 2
            eventAggregator.Subscribe<NewImageEvent>((s, a) =>
            {
                var args = a as NewImageEvent;
                Console.WriteLine($"Komp2: {args.Data}");
            });


            // --- Data
            var newImageEvent = new NewImageEvent { Data = 4711 };
            eventAggregator.Publish(null, newImageEvent);
        }

        static void HandleNewEvent(object sender, EventArgs e)
        {
            var args = e as NewImageEvent;
            Console.WriteLine("Komp 1: "+args.Data);
        }
    }
}
