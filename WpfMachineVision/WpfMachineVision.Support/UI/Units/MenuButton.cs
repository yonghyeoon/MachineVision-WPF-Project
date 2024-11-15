using System.Windows;
using System.Windows.Controls;

namespace WpfMachineVision.Support.UI.Units
{
    public class MenuButton : Button
    {
        static MenuButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MenuButton), new FrameworkPropertyMetadata(typeof(MenuButton)));
        }
    }
}