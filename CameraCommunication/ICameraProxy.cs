namespace CameraCommunication;

public interface ICameraProxy
{
    string Name { get; set; }
    void Start();
    void Stop();
}