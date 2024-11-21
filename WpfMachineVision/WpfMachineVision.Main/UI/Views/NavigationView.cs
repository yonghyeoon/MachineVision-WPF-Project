using System.Windows;
using System.Windows.Controls;
using WpfMachineVision.Main.Local.ViewModels;

namespace WpfMachineVision.Main.UI.Views
{
    public class NavigationView : Control
    {
        static NavigationView()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(NavigationView), new FrameworkPropertyMetadata(typeof(NavigationView)));
        }

        public NavigationView(NavigationViewModel navigationViewModel)
        {
            DataContext = navigationViewModel;
        }
    }
}
