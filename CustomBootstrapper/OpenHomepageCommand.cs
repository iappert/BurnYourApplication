// //-------------------------------------------------------------------------------
// // <copyright file="OpenHomepageCommand.cs" company="bbv Software Services AG">
// //  (c) bbv Software Services AG 2013
// // </copyright>
// //-------------------------------------------------------------------------------
namespace CustomBootstrapper
{
    using System;
    using System.Diagnostics;
    using System.Windows.Input;

    public class OpenHomepageCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            Process process = new Process();
            process.StartInfo.FileName = "www.bbv.ch";
            process.StartInfo.UseShellExecute = true;
            process.StartInfo.Verb = "open";

            process.Start();
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }
    }
}