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
            NavigationView NavigateContent = _containerProvider.Resolve<NavigationView>();
            IRegion NavigateRegion = _regionManager.Regions["NavigateRegion"];
            NavigateRegion.Add(NavigateContent);

            ImageContentView ViewerContent = _containerProvider.Resolve<ImageContentView>();
            IRegion ViewerRegion = _regionManager.Regions["ViewerRegion"];
            ViewerRegion.Add(ViewerContent);

            //ImageContentView ViewerContent = _containerProvider.Resolve<ImageContentView>();
            //IRegion ViewerRegion = _regionManager.Regions["OutputRegion"];
            //ViewerRegion.Add(ViewerContent);

            ImageControlView ControlContent = _containerProvider.Resolve<ImageControlView>();
            IRegion ControlRegion = _regionManager.Regions["ControlRegion"];
            ControlRegion.Add(ControlContent);
        }
    }
}
