using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace WpfMachineVision.Main.UI.Units
{
    public class ImageButton : RadioButton
    {
        static ImageButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ImageButton), new FrameworkPropertyMetadata(typeof(ImageButton)));
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
