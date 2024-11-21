using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows;

namespace WpfMachineVision.Main.Local.ViewModels
{
    public partial class NavigationViewModel : ObservableObject
    {
        private readonly IRegionManager _regionManager;

        public NavigationViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        [RelayCommand]
        private void OnNavigate(object navigatePath)
        {
            if (navigatePath is not Tuple<string, string> tuple)
            {
                return;
            }

            string viewerRegionString = tuple.Item1;
            string controlRegionString = tuple.Item2;

            _regionManager.RequestNavigate("ViewerRegion", viewerRegionString);
            _regionManager.RequestNavigate("ControlRegion", controlRegionString);
        }
    }
}
