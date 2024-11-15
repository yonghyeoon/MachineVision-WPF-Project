using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using WpfMachineVision.Main.Local.ViewModels;

namespace WpfMachineVision.Main.UI.Views
{
    public class LeftPanelView : Control
    {
        static LeftPanelView()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(LeftPanelView), new FrameworkPropertyMetadata(typeof(LeftPanelView)));
        }

        public LeftPanelView(LeftPanelViewModel panelViewModel)
        {
            DataContext = panelViewModel;
        }
    }
}
