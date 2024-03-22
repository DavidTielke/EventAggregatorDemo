using System.Security.AccessControl;
using System.Timers;
using EventAggregatorDemo;
using Timer = System.Timers.Timer;

namespace CameraCommunication
{
    public class CameraProxy : ICameraProxy
    {
        private readonly IEventAggregator _eventAggregator;
        private Timer _timer;

        public CameraProxy(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _timer = new Timer();
            _timer.Interval = 100;
            _timer.Elapsed += GetNewImage;
        }

        private void GetNewImage(object? sender, ElapsedEventArgs e)
        {
            var data = DateTime.Now.Ticks;
            var message = new NewImageEvent { Data = data, KameraName = Name};

            LastImage = data;

            _eventAggregator.Publish(this, message);
        }

        public string Name { get; set; }
        public long LastImage { get; set; }

        public long GetImage()
        {
            if (LastImage != 0)
            {
                return LastImage;
            }
            else
            {
                // Verbinden
                // Bild holen
                // Verbindung schließen
                return 0;
            }
        }

        public void Start()
        {
            _timer.Start();
        }

        public void Stop()
        {
            _timer.Stop();
        }
    }
}
