using System.Windows;
using System.Windows.Controls;
using WpfMachineVision.Main.Local.ViewModels;

namespace WpfMachineVision.Main.UI.Views
{
    public class ImageContentView : Control
    {
        static ImageContentView()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ImageContentView), new FrameworkPropertyMetadata(typeof(ImageContentView)));
        }

        public ImageContentView(ImageContentViewModel imageContentViewModel)
        {
            DataContext = imageContentViewModel;
        }
    }
}
