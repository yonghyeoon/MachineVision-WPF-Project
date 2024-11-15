using System.Windows;
using WpfMachineVision.Main.UI.Views;
using WpfMachineVision.Support.UI.Units;

namespace WpfMachineVision.Forms.UI.Views
{
    public class MachineVisionView : DarkWindow
    {
        private readonly IContainerProvider _containerProvider;
        private readonly IRegionManager _regionManager;

        static MachineVisionView()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MachineVisionView), new FrameworkPropertyMetadata(typeof(MachineVisionView)));
        }

        public MachineVisionView(IContainerProvider containerProvider, IRegionManager regionManager)
        {
            _containerProvider = containerProvider;
            _regionManager = regionManager;

            Loaded += MachineVisionView_Loaded;
        }

        private void MachineVisionView_Loaded(object sender, RoutedEventArgs e)
        {
            LeftPanelView LeftPanelContent = _containerProvider.Resolve<LeftPanelView>();
            IRegion LeftPanelRegion = _regionManager.Regions["LeftPanelRegion"];
            LeftPanelRegion.Add(LeftPanelContent);

            RightPanelView RightPanelContent = _containerProvider.Resolve<RightPanelView>();
            IRegion RightPanelRegion = _regionManager.Regions["RightPanelRegion"];
            RightPanelRegion.Add(RightPanelContent);

            CameraView CameraContent = _containerProvider.Resolve<CameraView>();
            IRegion CameraRegion = _regionManager.Regions["CameraRegion"];
            CameraRegion.Add(CameraContent);
        }
    }
}
