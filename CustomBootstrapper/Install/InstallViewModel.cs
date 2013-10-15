//-------------------------------------------------------------------------------
// <copyright file="InstallViewModel.cs" company="bbv Software Services AG">
//  (c) bbv Software Services AG 2013
// </copyright>
//-------------------------------------------------------------------------------
namespace CustomBootstrapper.Install
{
    using System;
    using System.Windows.Input;
    using System.Windows.Threading;
    using Microsoft.Tools.WindowsInstallerXml.Bootstrapper;

    public class InstallViewModel
    {
        private readonly BootstrapperApplication bootstrapperApplication;
        private Dispatcher dispatcher;

        public InstallViewModel(ICommand installCommand, ICommand openHomepageCommand, BootstrapperApplication bootstrapperApplication)
        {
            this.InstallCommand = installCommand;
            this.OpenHomepageCommand = openHomepageCommand;
            this.bootstrapperApplication = bootstrapperApplication;
        }

        public ICommand InstallCommand { get; private set; }

        public ICommand OpenHomepageCommand { get; private set; }

        public IntPtr ViewWindowHandle { get; set; }

        public void Initialize()
        {
            this.bootstrapperApplication.PlanComplete += this.OnPlanComplete;
            this.bootstrapperApplication.ApplyComplete += this.OnApplyComplete;
            this.dispatcher = Dispatcher.CurrentDispatcher;
        }

        private void OnApplyComplete(object sender, ApplyCompleteEventArgs applyCompleteEventArgs)
        {
            this.dispatcher.InvokeShutdown();
        }

        private void OnPlanComplete(object sender, PlanCompleteEventArgs planCompleteEventArgs)
        {
            this.bootstrapperApplication.Engine.Apply(this.ViewWindowHandle);       
        }
    }
}