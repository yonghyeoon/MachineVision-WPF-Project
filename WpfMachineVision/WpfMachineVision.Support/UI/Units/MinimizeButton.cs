using System.Windows;
using System.Windows.Controls;

namespace WpfMachineVision.Support.UI.Units
{
    public class MinimizeButton : Button
    {
        static MinimizeButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MinimizeButton), new FrameworkPropertyMetadata(typeof(MinimizeButton)));
        }

        public MinimizeButton()
        {
            Click += MinimizeButton_Click;
        }

        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            var win = Window.GetWindow(this);
            if (win.WindowState != WindowState.Minimized)
            {
                win.WindowState = WindowState.Minimized;
            }
            else
            {
                win.WindowState = WindowState.Normal;
            }
        }
    }
}
