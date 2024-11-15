using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using OpenCvSharp;
using OpenCvSharp.WpfExtensions;
using System.Windows;
using System.Windows.Media.Imaging;
using WpfMachineVision.Support.Common;
using WpfMachineVision.Support.Events;
using WpfMachineVision.Support.Interfaces;
using WpfMachineVision.Support.Services;

namespace WpfMachineVision.Main.Local.ViewModels
{
    public partial class CameraViewModel : ObservableObject
    {
        [ObservableProperty]
        public bool _faceDetectionChecked = false;

        public bool _GrayScaleChecked = false;
        public bool _CannyChecked = false;
        public bool _OCRChecked = false;

        [ObservableProperty]
        public WriteableBitmap _currentFrame;

        private readonly ICamera _cameraService;
        private readonly IEventAggregator _ea;
        private string cascadeFileName = @"D:\wpf_code\MachineVision-WPF-Project\WpfMachineVision\haarcascade_frontalface_default.xml";
        private HaarCascadeFaceDetector _Fd;
        private TesseractOCR _ocr;

        public CameraViewModel(ICamera cameraService, IEventAggregator ea)
        {
            _ea = ea;
            _ea.GetEvent<ImageSendEvent>().Subscribe(ImageReceived);
            _ea.GetEvent<CheckboxSelectedEvent>().Subscribe(CheckboxSelectReceived);

            _cameraService = cameraService;
            _cameraService.FrameCaptured += OnFrameCaptured;

            _Fd = new HaarCascadeFaceDetector(cascadeFileName);
            _ocr = new TesseractOCR();
        }

        private void CheckboxSelectReceived(CheckboxEventPayload payload)
        {
            switch (payload.Message)
            {
                case "GrayScale":
                    _GrayScaleChecked = payload.IsChecked;
                    break;
                case "Canny":
                    _CannyChecked = payload.IsChecked;
                    break;
                case "OCR":
                    _OCRChecked = payload.IsChecked;
                    break;
                default:
                    break;

            }
        }

        // private void MessageReceived(string parameter)
        // {
        //     switch (parameter)
        //     {
        //         case "GrayScale":
        //             MessageBox.Show("GrayScale!");
        //             break;
        //         case "Canny":
        //             MessageBox.Show("Canny!");
        //             break;
        //         default:
        //             break;
        //     }
        // }

        private void ImageReceived(WriteableBitmap parameter)
        {
            CurrentFrame = parameter;
        }

        private void OnFrameCaptured(Mat frame)
        {
            if (FaceDetectionChecked)
            {
                frame = _Fd.DetectFaces(frame);
            }
            else if (_GrayScaleChecked)
            {
                Cv2.CvtColor(frame, frame, ColorConversionCodes.BGR2GRAY); 
            }
            else if (_OCRChecked)
            {
                var text = _ocr.OcrGetText(frame);
                _ea.GetEvent<MessageSendEvent>().Publish(text);
            }

            Application.Current.Dispatcher.Invoke(() =>
            {
                CurrentFrame = frame.ToWriteableBitmap();
            });
        }

        [RelayCommand]
        public void OnDetection()
        {
            if (!FaceDetectionChecked)
            {
                return;
            }
            CurrentFrame = _Fd.DetectFaces(CurrentFrame.ToMat()).ToWriteableBitmap();
        }

        [RelayCommand]
        public void OnCamera(string command)
        {
            switch (command)
            {
                case "Start":
                    _cameraService.Start();
                    break;
                case "Stop":
                    _cameraService.Stop();
                    break;
                default:
                    break;
            }
        }

        public void Dispose()
        {
            _cameraService.FrameCaptured -= OnFrameCaptured;
            _cameraService.Dispose();
        }
    }
}
