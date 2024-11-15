using OpenCvSharp;
using System.Windows;
using WpfMachineVision.Support.Interfaces;

namespace WpfMachineVision.Support.Services
{
    public class OpenCvCamera : ICamera
    {
        private VideoCapture _vc;

        public bool IsOpen => _vc.IsOpened();

        public event Action<Mat> FrameCaptured;

        public void Dispose()
        {
            Stop();
            _vc?.Dispose();
        }

        public void Start(int cameraIndex=0)
        {
            _vc = new VideoCapture(cameraIndex);
            if (!_vc.IsOpened())
            {
                return;
            }

            Task.Run(() =>
            {
                using Mat frame = new();
                while (_vc.IsOpened())
                {
                    _vc.Read(frame);
                    if (!frame.Empty())
                    {
                        Application.Current.Dispatcher.BeginInvoke(() =>
                        {
                            FrameCaptured?.Invoke(frame);
                        });
                    }
                }
            });
        }

        public void Stop()
        {
            if (_vc.IsOpened())
            {
                _vc?.Release();
            }
        }
    }
}
