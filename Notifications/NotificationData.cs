using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WNSNotifier.Notifications
{

    /// <summary>
    /// Basic notfication data
    /// needed to authorize agains the 
    /// WNS service.
    /// </summary>
    [Serializable]
    class NotificationData
    {

        /// <summary>
        /// Gets or sets the channel URI.
        /// </summary>
        /// <value>
        /// The channel URI.
        /// </value>
        public string ChannelUri { get; set; }

        /// <summary>
        /// Gets or sets the package SID.
        /// </summary>
        /// <value>
        /// The package SID.
        /// </value>
        public string PackageSID { get; set; }

        /// <summary>
        /// Gets or sets the client secret.
        /// </summary>
        /// <value>
        /// The client secret.
        /// </value>
        public string ClientSecret { get; set; }
       
    }
}
