using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CameraCommunication;
using Microsoft.Extensions.DependencyInjection;

namespace CameraManagement
{
    public class CameraLocator : ICameraLocator
    {
        public ICameraProxy Camera1 { get; set; }
        public ICameraProxy Camera2 { get; set; }

        public CameraLocator(IServiceProvider provider)
        {
            Camera1 = provider.GetService<ICameraProxy>();
            Camera1.Name = "Camera 1";
            Camera2 = provider.GetService<ICameraProxy>();
            Camera2.Name = "Camera 2";
        }

        public void StartAll()
        {
            Camera1.Start();
            Camera2.Start();
        }
        public void StopAll()
        {
            Camera1.Stop();
            Camera2.Stop();
        }
    }
}
