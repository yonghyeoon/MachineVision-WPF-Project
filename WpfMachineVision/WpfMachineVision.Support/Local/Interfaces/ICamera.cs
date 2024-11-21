using OpenCvSharp;

namespace WpfMachineVision.Support.Local.Interfaces
{
    public interface ICamera : IDisposable
    {
        bool IsOpen { get; }
        event Action<Mat> FrameCaptured;
        void Start(int cameraIndex = 0);
        void Stop();
    }
}
