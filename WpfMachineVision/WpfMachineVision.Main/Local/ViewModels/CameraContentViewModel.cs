using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using OpenCvSharp.WpfExtensions;
using OpenCvSharp;
using System.Windows.Media.Imaging;
using WpfMachineVision.Support.Local.Common;
using WpfMachineVision.Support.Local.Events;
using WpfMachineVision.Support.Local.Interfaces;
using WpfMachineVision.Support.Local.Services;
using System.Windows;
using WpfMachineVision.Main.Local.Models;

namespace WpfMachineVision.Main.Local.ViewModels
{
    public partial class CameraContentViewModel : ObservableObject
    {
        //[ObservableProperty]
        //public bool _faceDetectionChecked = false;

        [ObservableProperty]
        public WriteableBitmap _currentFrame;

        private readonly ICamera _cameraService;
        private readonly CameraDataModel _cameraDataModel;
        private readonly IEventAggregator _ea;
        private string cascadeFileName = @"D:\wpf_code\MachineVision-WPF-Project\WpfMachineVision\haarcascade_frontalface_default.xml";
        private HaarCascadeFaceDetector _Fd;
        private TesseractOCR _ocr;

        public CameraContentViewModel(IEventAggregator ea, ICamera cameraService, CameraDataModel cameraDataModel)
        {
            _ea = ea;
            //_ea.GetEvent<ImageSendEvent>().Subscribe(ImageReceived);
            //_ea.GetEvent<CheckboxSelectedEvent>().Subscribe(CheckboxSelectReceived);

            _cameraDataModel = cameraDataModel;

            _cameraService = cameraService;
            _cameraService.FrameCaptured += OnFrameCaptured;

            _Fd = new HaarCascadeFaceDetector(cascadeFileName);
            _ocr = new TesseractOCR();
        }

        private void OnFrameCaptured(Mat frame)
        {
            //if (FaceDetectionChecked)
            //{
            //    frame = _Fd.DetectFaces(frame);
            //}
            if (_cameraDataModel.IsGrayScale)
            {
                Cv2.CvtColor(frame, frame, ColorConversionCodes.BGR2GRAY);
            }
            else if (_cameraDataModel.IsCanny)
            {
                Mat canny = new();
                Cv2.Canny(frame, canny, _cameraDataModel.CannyThreshValue1, _cameraDataModel.CannyThreshValue2);
                frame = canny;
            }
            else if (_cameraDataModel.IsOCR)
            {
                var text = _ocr.OcrGetText(frame);
                //_ea.GetEvent<MessageSendEvent>().Publish(text);
            }

            Application.Current.Dispatcher.Invoke(() =>
            {
                CurrentFrame = frame.ToWriteableBitmap();
            });
        }

        //[RelayCommand]
        //public void OnDetection()
        //{
        //    if (!FaceDetectionChecked)
        //    {
        //        return;
        //    }
        //    CurrentFrame = _Fd.DetectFaces(CurrentFrame.ToMat()).ToWriteableBitmap();
        //}

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
