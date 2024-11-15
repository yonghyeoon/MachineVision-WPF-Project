using CommunityToolkit.Mvvm.ComponentModel;

namespace WpfMachineVision.Main.Local.ViewModels
{
    public partial class LeftPanelViewModel : ObservableObject
    {
        [ObservableProperty]
        private string _testMessage;

        public LeftPanelViewModel()
        {
            TestMessage = "Test";
        }
    }
}
