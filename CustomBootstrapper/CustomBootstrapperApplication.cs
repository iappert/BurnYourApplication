//-------------------------------------------------------------------------------
// <copyright file="CustomBootstrapperApplication.cs" company="bbv Software Services AG">
//  (c) bbv Software Services AG 2013
// </copyright>
//-------------------------------------------------------------------------------
namespace CustomBootstrapper
{
    using System.Windows.Interop;
    using CustomBootstrapper.Install;
    using CustomBootstrapper.Uninstall;
    using Microsoft.Tools.WindowsInstallerXml.Bootstrapper;

    public class CustomBootstrapperApplication : BootstrapperApplication
    {
        protected override void Run()
        {
            this.Engine.Detect();

            if (this.Command.Action == LaunchAction.Install)
            {
                this.ShowInstallView();
            }
            else
            {
                this.ShowUninstallView();   
            }

            this.Engine.Quit(0);
        }

        private void ShowInstallView()
        {
            InstallViewModel viewModel = new InstallViewModel(new InstallCommand(this.Engine), new OpenHomepageCommand(), this);
            viewModel.Initialize();

            InstallView view = new InstallView();
            view.DataContext = viewModel;
            viewModel.ViewWindowHandle = new WindowInteropHelper(view).EnsureHandle();
            
            view.ShowDialog();
        }

        private void ShowUninstallView()
        {
            UninstallViewModel viewModel = new UninstallViewModel(new UninstallCommand(this.Engine), new OpenHomepageCommand(), this);

            UninstallView view = new UninstallView();
            view.DataContext = viewModel;
            viewModel.ViewWindowHandle = new WindowInteropHelper(view).EnsureHandle();

            view.ShowDialog();
        }
    }
}