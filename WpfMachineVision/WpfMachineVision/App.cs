using System.Windows;
using WpfMachineVision.Forms.UI.Views;
using WpfMachineVision.Main.Local.Models;
using WpfMachineVision.Main.Local.ViewModels;
using WpfMachineVision.Main.UI.Views;
using WpfMachineVision.Support.Local.Interfaces;
using WpfMachineVision.Support.Local.Services;

namespace WpfMachineVision
{
    public class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MachineVisionView>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<ICamera, OpenCvCamera>();
            containerRegistry.RegisterSingleton<ImageDataModel>();
            containerRegistry.RegisterSingleton<CameraDataModel>();
            containerRegistry.RegisterForNavigation<ImageContentView>();
            containerRegistry.RegisterForNavigation<ImageControlView>();
            containerRegistry.RegisterForNavigation<CameraContentView>();
            containerRegistry.RegisterForNavigation<CameraControlView>();
        }
    }
}
