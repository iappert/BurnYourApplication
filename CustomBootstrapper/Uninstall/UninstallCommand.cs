// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UninstallCommand.cs" company="bbv Software Services AG">
//   (c) bbv Software Services AG 2013
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CustomBootstrapper.Uninstall
{
    using System;
    using System.Windows.Input;
    using Microsoft.Tools.WindowsInstallerXml.Bootstrapper;

    public class UninstallCommand : ICommand
    {
        private readonly Engine engine;

        public UninstallCommand(Engine engine)
        {
            this.engine = engine;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            this.engine.Plan(LaunchAction.Uninstall);
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

    }
}