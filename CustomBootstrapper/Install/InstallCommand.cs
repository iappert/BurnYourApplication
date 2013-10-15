//-------------------------------------------------------------------------------
// <copyright file="InstallCommand.cs" company="bbv Software Services AG">
//  (c) bbv Software Services AG 2013
// </copyright>
//-------------------------------------------------------------------------------
namespace CustomBootstrapper.Install
{
    using System;
    using System.Windows.Input;
    using Microsoft.Tools.WindowsInstallerXml.Bootstrapper;

    public class InstallCommand : ICommand
    {
        private readonly Engine engine;

        public InstallCommand(Engine engine)
        {
            this.engine = engine;
        }

        public event EventHandler CanExecuteChanged = delegate { };

        public void Execute(object parameter)
        {
            this.engine.Plan(LaunchAction.Install);
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }
    }
}