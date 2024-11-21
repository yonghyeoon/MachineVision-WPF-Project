using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Win32;
using OpenCvSharp;
using System.Windows;
using WpfMachineVision.Main.Local.Models;

namespace WpfMachineVision.Main.Local.ViewModels
{
    public partial class CameraControlViewModel : ObservableObject
    {
        private readonly IEventAggregator _ea;
        private readonly CameraDataModel _cameraDataModel;

        public CameraControlViewModel(IEventAggregator ea, CameraDataModel cameraDataModel)
        {
            _ea = ea;
            _cameraDataModel = cameraDataModel;
            _cameraDataModel.PropertyChanged += _cameraDataModel_PropertyChanged;
        }

        private void _cameraDataModel_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            OnPropertyChanged(e.PropertyName);
        }

        public Mat? OriginalImage
        {
            get => _cameraDataModel.OriginalImage;
            set => _cameraDataModel.OriginalImage = value;
        }

        public bool IsOriginal
        {
            get => _cameraDataModel.IsOriginal;
            set => _cameraDataModel.IsOriginal = value;

        }

        public bool IsGrayScale
        {
            get => _cameraDataModel.IsGrayScale;
            set => _cameraDataModel.IsGrayScale = value;
        }

        public bool IsCanny
        {
            get => _cameraDataModel.IsCanny;
            set => _cameraDataModel.IsCanny = value;
        }

        public bool IsOCR
        {
            get => _cameraDataModel.IsOCR;
            set => _cameraDataModel.IsOCR = value;
        }

        public int CannyThreshValue1
        {
            get => _cameraDataModel.CannyThreshValue1;
            set => _cameraDataModel.CannyThreshValue1 = value;
        }

        public int CannyThreshValue2
        {
            get => _cameraDataModel.CannyThreshValue2;
            set => _cameraDataModel.CannyThreshValue2 = value;
        }

        [RelayCommand]
        public void OnImageControl(string param)
        {
            switch (param)
            {
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
