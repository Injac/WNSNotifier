using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;

namespace WNSNotifier.ViewModels
{
    class MainViewModel
    {

        /// <summary>
        /// The _show settings window
        /// </summary>
        private ICommand _showSettingsWindow;

        /// <summary>
        /// Gets or sets the show settings window.
        /// </summary>
        /// <value>
        /// The show settings window.
        /// </value>
        public ICommand ShowSettingsWindow
        {
            get { return _showSettingsWindow; }
            set { _showSettingsWindow = value; }
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="MainViewModel" /> class.
        /// </summary>
        public MainViewModel()
        {
            this.ShowSettingsWindow = new DelegateCommand(this.ShowSettingsWnd);
        }

        /// <summary>
        /// Shows the settings WND.
        /// </summary>
        private void ShowSettingsWnd()
        {
            WNSNotifier.Settings wnd = new Settings();

            wnd.WindowStartupLocation = WindowStartupLocation.CenterOwner;

            wnd.Owner = App.Current.MainWindow;

            wnd.Show();
            
        }
    }
}
