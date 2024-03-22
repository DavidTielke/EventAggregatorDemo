using CameraCommunication;
using CameraManagement;
using EventAggregatorDemo;
using Microsoft.Extensions.DependencyInjection;

namespace WpfClient;

public static class Kernel
{
    public static ServiceProvider Instance { get; }

    static Kernel()
    {
        var serviceCollection = new ServiceCollection();

        serviceCollection.AddSingleton<IEventAggregator, EventAggregator>();
        serviceCollection.AddTransient<ICameraProxy, CameraProxy>();
        serviceCollection.AddTransient<ICameraManager, CameraManager>();
        serviceCollection.AddSingleton<ICameraLocator, CameraLocator>();

        Instance = serviceCollection.BuildServiceProvider();
    }
}