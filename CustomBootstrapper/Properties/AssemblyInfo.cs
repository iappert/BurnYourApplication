//-------------------------------------------------------------------------------
// <copyright file="AssemblyInfo.cs" company="bbv Software Services AG">
//  (c) bbv Software Services AG 2013
// </copyright>
//-------------------------------------------------------------------------------

using System.Reflection;
using CustomBootstrapper;
using Microsoft.Tools.WindowsInstallerXml.Bootstrapper;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("WiXArtikelBootstrapper")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]
[assembly: BootstrapperApplication(typeof(CustomBootstrapperApplication))]