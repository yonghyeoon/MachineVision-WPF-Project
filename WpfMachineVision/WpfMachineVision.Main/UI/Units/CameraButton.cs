using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WpfMachineVision.Main.UI.Units
{
    public class CameraButton : RadioButton
    {
        static CameraButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CameraButton), new FrameworkPropertyMetadata(typeof(CameraButton)));
        }

        protected override void OnPreviewMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            if (this.IsChecked == true)
            {
                e.Handled = true;
            }
            else
            {
                base.OnPreviewMouseLeftButtonDown(e);
            }
        }
    }
}
