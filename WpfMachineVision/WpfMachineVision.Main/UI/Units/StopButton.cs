using System.Windows;
using System.Windows.Controls;

namespace WpfMachineVision.Main.UI.Units
{
    public class StopButton : Button
    {
        static StopButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(StopButton), new FrameworkPropertyMetadata(typeof(StopButton)));
        }
    }
}
