using CameraCommunication;

namespace CameraManagement;

public interface ICameraLocator
{
    ICameraProxy Camera1 { get; set; }
    ICameraProxy Camera2 { get; set; }
    void StartAll();
    void StopAll();
}