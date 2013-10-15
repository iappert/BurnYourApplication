// //-------------------------------------------------------------------------------
// // <copyright file="UninstallViewModel.cs" company="bbv Software Services AG">
// //  (c) bbv Software Services AG 2013
// // </copyright>
// //-------------------------------------------------------------------------------
namespace CustomBootstrapper.Uninstall
{
    using System;
    using System.Windows.Input;
    using System.Windows.Threading;
    using Microsoft.Tools.WindowsInstallerXml.Bootstrapper;

    public class UninstallViewModel
    {
        private readonly BootstrapperApplication customBootstrapperApplication;
        private Dispatcher dispatcher;

        public UninstallViewModel(ICommand uninstallCommand, ICommand openHomepageCommand, BootstrapperApplication customBootstrapperApplication)
        {
            this.UninstallCommand = uninstallCommand;
            this.OpenHomepageCommand = openHomepageCommand;
            this.customBootstrapperApplication = customBootstrapperApplication;
            this.Initialize();
        }

        public IntPtr ViewWindowHandle { get; set; }

        public ICommand UninstallCommand { get; private set; }

        public ICommand OpenHomepageCommand { get; private set; }

        private void Initialize()
        {
            this.customBootstrapperApplication.PlanComplete += this.OnPlanComplete;
            this.customBootstrapperApplication.ApplyComplete += this.OnApplyComplete;
            this.dispatcher = Dispatcher.CurrentDispatcher;
        }

        private void OnApplyComplete(object sender, ApplyCompleteEventArgs applyCompleteEventArgs)
        {
            this.dispatcher.InvokeShutdown();
        }

        private void OnPlanComplete(object sender, PlanCompleteEventArgs planCompleteEventArgs)
        {
            this.customBootstrapperApplication.Engine.Apply(this.ViewWindowHandle);
        }
    }
}