using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using WpfMachineVision.Main.Local.ViewModels;

namespace WpfMachineVision.Main.UI.Views
{
    public class RightPanelView : Control
    {
        static RightPanelView()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(RightPanelView), new FrameworkPropertyMetadata(typeof(RightPanelView)));
        }

        public RightPanelView(RightPanelViewModel panelViewModel)
        {
            DataContext = panelViewModel;
        }
    }
}
