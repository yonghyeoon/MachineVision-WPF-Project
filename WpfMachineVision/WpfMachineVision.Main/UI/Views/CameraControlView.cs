using System.Windows;
using System.Windows.Controls;
using WpfMachineVision.Main.Local.ViewModels;

namespace WpfMachineVision.Main.UI.Views
{
    public class CameraControlView : Control
    {
        static CameraControlView()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CameraControlView), new FrameworkPropertyMetadata(typeof(CameraControlView)));
        }

        public CameraControlView(CameraControlViewModel cameraControlViewModel) 
        {
            DataContext = cameraControlViewModel;
        }
    }
}
