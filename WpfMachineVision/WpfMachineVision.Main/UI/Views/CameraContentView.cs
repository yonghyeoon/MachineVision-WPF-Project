using System.Windows;
using System.Windows.Controls;
using WpfMachineVision.Main.Local.ViewModels;

namespace WpfMachineVision.Main.UI.Views
{
    public class CameraContentView : Control
    {
        static CameraContentView()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CameraContentView), new FrameworkPropertyMetadata(typeof(CameraContentView)));
        }

        public CameraContentView(CameraContentViewModel cameraContentViewModel)
        {
            DataContext = cameraContentViewModel;
        }
    }
}
