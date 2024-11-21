using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Win32;
using OpenCvSharp;
using System.Windows.Media.Imaging;
using System.Windows;
using OpenCvSharp.WpfExtensions;
using WpfMachineVision.Support.Local.Services;
using WpfMachineVision.Support.Local.Events;
using WpfMachineVision.Main.Local.Models;

namespace WpfMachineVision.Main.Local.ViewModels
{
    public partial class ImageContentViewModel : ObservableObject
    {
        private readonly IEventAggregator _ea;
        private readonly ImageDataModel _imageDataModel;

        [ObservableProperty]
        public WriteableBitmap? _viewerImage = null;

        private string cascadeFileName = @"D:\wpf_code\MachineVision-WPF-Project\WpfMachineVision\haarcascade_frontalface_default.xml";
        private HaarCascadeFaceDetector _Fd;
        private TesseractOCR _ocr;

        public ImageContentViewModel(IEventAggregator ea, ImageDataModel imageDataModel)
        {
            _ea = ea;
            // ea.GetEvent<ImageSendEvent>().Subscribe(OnReceiveImage);

            _Fd = new HaarCascadeFaceDetector(cascadeFileName);
            _ocr = new TesseractOCR();

            _imageDataModel = imageDataModel;
            _imageDataModel.PropertyChanged += ImageDataModel_PropertyChanged;
        }

        private void ImageDataModel_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "OriginalImage":
                    ViewerImage = _imageDataModel.OriginalImage?.ToWriteableBitmap();
                    break;

                case "IsOriginal":
                    if (_imageDataModel.IsOriginal && _imageDataModel.OriginalImage != null)
                    {
                        ViewerImage = _imageDataModel.OriginalImage?.ToWriteableBitmap();
                    }
                    break;

                case "IsGrayScale":
                    if (_imageDataModel.IsGrayScale && _imageDataModel.OriginalImage != null) 
                    {
                        Mat grayImage = new();
                        Cv2.CvtColor(_imageDataModel.OriginalImage, grayImage, ColorConversionCodes.BGR2GRAY);
                        ViewerImage = grayImage.ToWriteableBitmap()!;
                    }
                    break;

                case "IsCanny":
                    if (_imageDataModel.IsCanny && _imageDataModel.OriginalImage != null)
                    {
                        Mat canny = new();
                        Cv2.Canny(_imageDataModel.OriginalImage, canny, _imageDataModel.CannyThreshValue1, _imageDataModel.CannyThreshValue2);
                        ViewerImage = canny.ToWriteableBitmap();
                    }
                    break;

                case "CannyThreshValue1":
                    if (_imageDataModel.IsCanny && _imageDataModel.OriginalImage != null)
                    {
                        Mat canny = new();
                        Cv2.Canny(_imageDataModel.OriginalImage, canny, _imageDataModel.CannyThreshValue1, _imageDataModel.CannyThreshValue2);
                        ViewerImage = canny.ToWriteableBitmap();
                    }
                    break;

                case "CannyThreshValue2":
                    if (_imageDataModel.IsCanny && _imageDataModel.OriginalImage != null)
                    {
                        Mat canny = new();
                        Cv2.Canny(_imageDataModel.OriginalImage, canny, _imageDataModel.CannyThreshValue1, _imageDataModel.CannyThreshValue2);
                        ViewerImage = canny.ToWriteableBitmap();
                    }
                    break;

                case "IsOCR":
                    if (_imageDataModel.IsOCR && _imageDataModel.OriginalImage != null)
                    {
                        string text = _ocr.OcrGetText(_imageDataModel.OriginalImage);
                        if (!string.IsNullOrEmpty(text))
                        {
                            _ea.GetEvent<OcrResultSendEvent>().Publish(text);
                        }   
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
