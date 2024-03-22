using System.ComponentModel;
using System.Diagnostics.Eventing.Reader;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CameraManagement;
using EventAggregatorDemo;
using Microsoft.Extensions.DependencyInjection;

namespace WpfClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private long _imageData1;
        private long _imageData2;
        private readonly ICameraLocator? _cameraLocator;


        public MainWindow()
        {
            _cameraLocator = Kernel.Instance.GetService<ICameraLocator>();

            var eventAggregator = Kernel.Instance.GetService<IEventAggregator>();
            eventAggregator.Subscribe<NewImageEvent>(NewImageEventHandler);

            DataContext = this;
            InitializeComponent();

            ImageData1 = 0815;
        }

        public long ImageData1
        {
            get => _imageData1;
            set
            {
                if (value == _imageData1) return;
                _imageData1 = value;
                OnPropertyChanged();
            }
        }
        public long ImageData2
        {
            get => _imageData2;
            set
            {
                if (value == _imageData2) return;
                _imageData2 = value;
                OnPropertyChanged();
            }
        }

        public void NewImageEventHandler(object sender, EventArgs e)
        {
            var args = e as NewImageEvent;

            if (args.KameraName == "Camera 1")
            {
                ImageData1 = args.Data;
            }
            else
            {
                ImageData2 = args.Data;
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _cameraLocator.StartAll();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            _cameraLocator.StopAll();
        }
    }
}