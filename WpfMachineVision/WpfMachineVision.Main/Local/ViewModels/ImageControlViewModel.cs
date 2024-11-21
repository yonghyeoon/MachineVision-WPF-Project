using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Win32;
using OpenCvSharp;
using System.Windows;
using WpfMachineVision.Main.Local.Models;
using WpfMachineVision.Support.Local.Events;

namespace WpfMachineVision.Main.Local.ViewModels
{
    public partial class ImageControlViewModel : ObservableObject
    {
        private readonly IEventAggregator _ea;
        private readonly ImageDataModel _imageDataModel;

        [ObservableProperty]
        private string _oCRResult;

        public ImageControlViewModel(IEventAggregator ea, ImageDataModel imageDataModel)
        {
            _ea = ea;
            _ea.GetEvent<OcrResultSendEvent>().Subscribe(OcrResultReceived);
            _imageDataModel = imageDataModel;
            _imageDataModel.PropertyChanged += _imageDataModel_PropertyChanged;
        }

        private void _imageDataModel_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            OnPropertyChanged(e.PropertyName);
        }

        private void OcrResultReceived(string obj)
        {
            OCRResult = obj;
        }

        public Mat? OriginalImage
        {
            get => _imageDataModel.OriginalImage;
            set => _imageDataModel.OriginalImage = value;
        }

        public bool IsOriginal
        {
            get => _imageDataModel.IsOriginal;
            set => _imageDataModel.IsOriginal = value;
            
        }

        public bool IsGrayScale
        {
            get => _imageDataModel.IsGrayScale;
            set => _imageDataModel.IsGrayScale = value;
        }

        public bool IsCanny
        {
            get => _imageDataModel.IsCanny;
            set => _imageDataModel.IsCanny = value;
        }

        public bool IsOCR
        {
            get => _imageDataModel.IsOCR;
            set => _imageDataModel.IsOCR = value;
        }

        public int CannyThreshValue1
        {
            get => _imageDataModel.CannyThreshValue1;
            set => _imageDataModel.CannyThreshValue1 = value;
        }

        public int CannyThreshValue2
        {
            get => _imageDataModel.CannyThreshValue2;
            set => _imageDataModel.CannyThreshValue2 = value;
        }

        [RelayCommand]
        public void OnImageControl(string param)
        {
            switch (param)
            {
                case "Load":
                    OpenFileDialog openFileDialog = new();
                    openFileDialog.Title = "File Open Test";
                    openFileDialog.Filter = "그림 파일 (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png; | 모든 파일 (*.*) | *.*";

                    bool? ret = openFileDialog.ShowDialog();
                    if ((bool)ret!)
                    {
                        OriginalImage = new Mat(openFileDialog.FileName);
                        IsOriginal = true;
                        //_ea.GetEvent<ImageSendEvent>().Publish(new Mat(openFileDialog.FileName));
                    }
                    break;
                case "Save":
                    MessageBox.Show("Save!");
                    break;
                default:
                    break;
            }
        }

        [RelayCommand]
        public void OnSliderValue1Changed(double value)
        {
            CannyThreshValue1 = (int)value;
        }

        [RelayCommand]
        public void OnSliderValue2Changed(double value)
        {
            CannyThreshValue2 = (int)value;
        }
    }
}
