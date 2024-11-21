using System.Windows;
using System.Windows.Controls;
using WpfMachineVision.Main.Local.ViewModels;

namespace WpfMachineVision.Main.UI.Views
{
    public class ImageControlView : Control
    {
        static ImageControlView()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ImageControlView), new FrameworkPropertyMetadata(typeof(ImageControlView)));
        }

        public ImageControlView(ImageControlViewModel imageControlViewModel)
        {
            DataContext = imageControlViewModel;
        }
    }
}
