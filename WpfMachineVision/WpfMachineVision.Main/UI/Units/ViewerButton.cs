using System.Windows;
using System.Windows.Controls;

namespace WpfMachineVision.Main.UI.Units
{
    public class ViewerButton : Button
    {
        static ViewerButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ViewerButton), new FrameworkPropertyMetadata(typeof(ViewerButton)));
        }
    }
}
