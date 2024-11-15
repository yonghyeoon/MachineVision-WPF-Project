using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Win32;
using OpenCvSharp;
using OpenCvSharp.WpfExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
using WpfMachineVision.Support.Common;
using WpfMachineVision.Support.Events;

namespace WpfMachineVision.Main.Local.ViewModels
{
    public partial class RightPanelViewModel : ObservableObject
    {
        private readonly IEventAggregator _ea;

        [ObservableProperty]
        private string _oCRResult;

        private bool _isGrayScaleChecked;
        public bool IsGrayScaleChecked
        {
            get { return _isGrayScaleChecked; }
            set 
            { 
                _isGrayScaleChecked = value;
                var payload = new CheckboxEventPayload("GrayScale", _isGrayScaleChecked);
                _ea.GetEvent<CheckboxSelectedEvent>().Publish(payload);
            }
        }

        private bool _isCannyChecked;
        public bool IsCannyChecked
        {
            get { return _isCannyChecked; }
            set
            {
                _isCannyChecked = value;
                var payload = new CheckboxEventPayload("Canny", _isCannyChecked);
                _ea.GetEvent<CheckboxSelectedEvent>().Publish(payload);
            }
        }

        private bool _isOCRChecked;
        public bool IsOCRChecked
        {
            get { return _isOCRChecked; }
            set
            {
                _isOCRChecked = value;
                var payload = new CheckboxEventPayload("OCR", _isOCRChecked);
                _ea.GetEvent<CheckboxSelectedEvent>().Publish(payload);
            }
        }

        public RightPanelViewModel(IEventAggregator ea)
        {
            _ea = ea;
            _ea.GetEvent<MessageSendEvent>().Subscribe(MessageReceived);
        }

        private void MessageReceived(string parameter)
        {
            if (!string.IsNullOrEmpty(parameter))
            {
                OCRResult = parameter;
            }
        }

        [RelayCommand]
        private void OnLoadImage()
        {
            OpenFileDialog openFileDialog = new();
            openFileDialog.Title = "File Open Test";
            openFileDialog.Filter = "그림 파일 (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png; | 모든 파일 (*.*) | *.*";

            bool? ret = openFileDialog.ShowDialog();
            if ((bool)ret!)
            {
                WriteableBitmap Image = Cv2.ImRead(openFileDialog.FileName).ToWriteableBitmap();
                _ea.GetEvent<ImageSendEvent>().Publish(Image);
            }
        }

        [RelayCommand]
        private void OnSaveImage()
        {
            MessageBox.Show("OnSaveImage!");
        }

        
    }
}
