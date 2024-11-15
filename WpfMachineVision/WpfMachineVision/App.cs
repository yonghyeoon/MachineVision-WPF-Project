﻿using System.Windows;
using WpfMachineVision.Forms.UI.Views;
using WpfMachineVision.Main.Local.ViewModels;
using WpfMachineVision.Main.UI.Views;
using WpfMachineVision.Support.Interfaces;
using WpfMachineVision.Support.Services;

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
        }
    }
}