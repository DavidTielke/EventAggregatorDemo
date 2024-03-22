using CameraCommunication;

namespace CameraManagement
{
    public class CameraManager : ICameraManager
    {
        private readonly ICameraProxy _cameraProxy;

        public CameraManager(ICameraProxy cameraProxy)
        {
            _cameraProxy = cameraProxy;
        }

        public void Start()
        {
            _cameraProxy.Start();
        }

        public void Stop()
        {
            _cameraProxy.Stop();
        }
    }
}
