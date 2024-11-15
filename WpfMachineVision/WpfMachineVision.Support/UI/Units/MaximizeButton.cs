using System.Windows;
using System.Windows.Controls;

namespace WpfMachineVision.Support.UI.Units
{
    public class MaximizeButton : Button
    {
        static MaximizeButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MaximizeButton), new FrameworkPropertyMetadata(typeof(MaximizeButton)));
        }

        public MaximizeButton()
        {
            Click += MaximizeButton_Click;
        }

        private void MaximizeButton_Click(object sender, RoutedEventArgs e)
        {
            var win = Window.GetWindow(this);
            if (win.WindowState != WindowState.Maximized)
            {
                win.WindowState = WindowState.Maximized;
            }
            else
            {
                win.WindowState = WindowState.Normal;
            }
        }
    }
}
