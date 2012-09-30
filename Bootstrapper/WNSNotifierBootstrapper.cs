using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MahApps.Metro.Controls;
using Microsoft.Practices.Prism.UnityExtensions;
using Microsoft.Practices.ServiceLocation;

namespace WNSNotifier.Bootstrapper
{
    class WNSNotifierBootstrapper:UnityBootstrapper 
    {
        /// <summary>
        /// Creates the shell (Basic UI for WNSNotifier.
        /// </summary>
        /// <returns>The Main Window</returns>
        protected override System.Windows.DependencyObject CreateShell()
        {
            return ServiceLocator.Current.GetInstance<MainWindow>();   
        }

        /// <summary>
        /// Initializes the shell.
        /// </summary>
        protected override void InitializeShell()
        {
            base.InitializeShell();

            Application.Current.MainWindow = (MetroWindow)this.Shell;
            Application.Current.MainWindow.Show();

        }


    }
}
