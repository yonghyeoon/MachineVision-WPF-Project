using CommunityToolkit.Mvvm.ComponentModel;
using OpenCvSharp;

namespace WpfMachineVision.Main.Local.Models
{
    public partial class ImageDataModel : ObservableObject
    {
        [ObservableProperty]
        private Mat? _originalImage = null;

        [ObservableProperty]
        private bool _isOriginal = true;

        [ObservableProperty]
        private bool _isGrayScale = false;

        [ObservableProperty]
        private bool _isCanny = false;

        [ObservableProperty]
        private bool _isOCR = false;

        [ObservableProperty]
        private int _cannyThreshValue1 = 0;

        [ObservableProperty]
        private int _cannyThreshValue2 = 0;
    }
}
