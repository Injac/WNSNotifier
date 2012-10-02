using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WNSNotifier.DataValidation;

namespace WNSNotifier.WebServer
{
    /// <summary>
    /// Settings for the webserver.
    /// </summary>
    [Serializable]
    public class WebServerSettings
    {
        /// <summary>
        /// The _ web server port
        /// </summary>
        private int _webServerPort;
        
        /// <summary>
        /// The _ enable directory browsing
        /// </summary>
        private bool _enableDirectoryBrowsing;

        /// <summary>
        /// Gets or sets the web server port.
        /// </summary>
        /// <value>
        /// The web server port.
        /// </value>
        [NumberValidation]
        public int WebServerPort
        {
            get { return _webServerPort; }
            set { _webServerPort = value; }
        }

      

        /// <summary>
        /// Gets or sets a value indicating whether [enable directory browsing].
        /// </summary>
        /// <value>
        /// <c>true</c> if [enable directory browsing]; otherwise, <c>false</c>.
        /// </value>
        public bool EnableDirectoryBrowsing
        {
            get { return _enableDirectoryBrowsing; }
            set { _enableDirectoryBrowsing = value; }
        }


    }
}
