using System.Windows;
using System.Windows.Controls;
using WpfMachineVision.Main.Local.ViewModels;

namespace WpfMachineVision.Main.UI.Views
{
    public class CameraView : Control
    {
        static CameraView()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CameraView), new FrameworkPropertyMetadata(typeof(CameraView)));
        }

        public CameraView(CameraViewModel mainContentViewModel)
        {
            DataContext = mainContentViewModel;
        }
    }
}
