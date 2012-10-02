using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Expression.Interactivity.Core;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Unity;
using WNSNotifier.DataValidation;
using WNSNotifier.Notifications;
using WNSNotifier.Services;
using WNSNotifier.WebServer;

namespace WNSNotifier.ViewModels
{
    internal class SettingsViewModel : INotifyPropertyChanged
    {

        /// <summary>
        /// The _serialize data command
        /// </summary>
        private ICommand _serializeDataCommand;


        /// <summary>
        /// Gets the serialize data command.
        /// </summary>
        /// <value>
        /// The serialize data command.
        /// </value>
        public ICommand SerializeDataCommand
        {
            get { return _serializeDataCommand; }
            set { this._serializeDataCommand = value; }
        }


        /// <summary>
        /// The _deserialize command
        /// </summary>
        private ICommand _deserializeCommand;

        /// <summary>
        /// Gets the deserialize command.
        /// </summary>
        /// <value>
        /// The deserialize command.
        /// </value>
        public ICommand DeserializeCommand
        {
            get { return _deserializeCommand; }
            set { this._deserializeCommand = value; }

        }


        /// <summary>
        /// The errors
        /// </summary>
        private Dictionary<String, List<String>> errors = new Dictionary<string, List<string>>();



        /// <summary>
        /// The I d_ NUMBERI c_ ERROR
        /// </summary>
        private const string ID_NUMBERIC_ERROR = "Value must be numeric.";

        /// <summary>
        /// The I d_ VALI d_ UR l_ ERROR
        /// </summary>
        private const string ID_VALID_URL_ERROR = "Value must be a valid url.";
       


        /// <summary>
        /// The _notification settings file name
        /// </summary>
        private readonly string _notificationSettingsFileName = "NotificaitonSettings.xml";

        /// <summary>
        /// The _web server config file name
        /// </summary>
        private readonly string _webServerConfigFileName = "config.ini";


        /// <summary>
        /// The _web server XML serilaization file
        /// </summary>
        private readonly string _webServerXmlSerilaizationFile = "WebServerSettings.xml";


        /// <summary>
        /// Gets or sets the _current assembly path.
        /// </summary>
        /// <value>
        /// The _current assembly path.
        /// </value>
        private string CurrentAssemblyPath { get; set; }


        /// <summary>
        /// Gets or sets the current notification settings path.
        /// </summary>
        /// <value>
        /// The current notification settings path.
        /// </value>
        private string CurrentNotificationSettingsPath { get; set; }


        /// <summary>
        /// Gets or sets the current web rootpath.
        /// </summary>
        /// <value>
        /// The current web rootpath.
        /// </value>
        private string CurrentWebRootpath { get; set; }

        /// <summary>
        /// The _notification data
        /// </summary>
        private NotificationData _notificationData;

        /// <summary>
        /// The _web server settings
        /// </summary>
        private WebServerSettings _webServerSettings;

        /// <summary>
        /// Gets or sets the _XML serializer.
        /// </summary>
        /// <value>
        /// The _XML serializer.
        /// </value>
        private IXmlSerializer<NotificationData> _xmlSerializer { get; set; }

        /// <summary>
        /// Gets or sets the _XML serializer webserver settings.
        /// </summary>
        /// <value>
        /// The _XML serializer webserver settings.
        /// </value>
        private IXmlSerializer<WebServerSettings> _xmlSerializerWebserverSettings { get; set; } 

        /// <summary>
        /// Gets or sets the notification data.
        /// </summary>
        /// <value>
        /// The notification data.
        /// </value>
        public NotificationData NotificationData
        {
            get { return _notificationData; }
            set
            {
                if (this._notificationData != value)
                {
                    _notificationData = value;
                    NotfiyPropertyChanged("NotificationData");
                }
            }
        }

        /// <summary>
        /// The _web server settings
        /// </summary>
        public WebServerSettings WebServerSettings
        {
            get { return _webServerSettings; }
            set
            {
                if (this._webServerSettings != value)
                {
                    _webServerSettings = value;
                    NotfiyPropertyChanged("WebServerSettings");
                }
            }
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="SettingsViewModel" /> class.
        /// </summary>
        public SettingsViewModel()
        {
            this.CurrentAssemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            this._xmlSerializer = new XmlNotificationDataSerializerService();
            this._xmlSerializerWebserverSettings = new XmlWebServerSettingsSerializerService();

            this.NotificationData = new NotificationData();

            this._webServerSettings = new WebServerSettings();

            if (CurrentAssemblyPath != null)
            {
                this.CurrentNotificationSettingsPath = Path.Combine(CurrentAssemblyPath, "Settings");
                this.CurrentWebRootpath = Path.Combine(CurrentAssemblyPath, "Webroot");
            }

            this.SerializeDataCommand = new ActionCommand(this.SerializeData);
            this.DeserializeCommand = new DelegateCommand(this.DeserializeData);

            //If we have already a file, go and get it!
            this.DeserializeData();
        }


        /// <summary>
        /// Serializes the data.
        /// </summary>
        private void SerializeData(object parameter)
        {

            WNSNotifier.Settings _wnd = new Settings();

            if(parameter != null)
            {
                
                _wnd = parameter as WNSNotifier.Settings;
                
            }

            this._xmlSerializer.Serialize(this.NotificationData,
                                          this.CurrentNotificationSettingsPath + @"\" + _notificationSettingsFileName);

            this._xmlSerializerWebserverSettings.Serialize(this.WebServerSettings,
                                          this.CurrentNotificationSettingsPath + @"\" + _webServerXmlSerilaizationFile);

            this.SaveWebServerConfigToWebRoot();

            if (_wnd != null) _wnd.Close();
        }


        /// <summary>
        /// Deserializes the data.
        /// </summary>
        private void DeserializeData()
        {

            if (File.Exists(this.CurrentNotificationSettingsPath + @"\" + _notificationSettingsFileName))
            {
                this.NotificationData =
                    this._xmlSerializer.Desirialize(this.CurrentNotificationSettingsPath + @"\" +
                                                    _notificationSettingsFileName);
            }


            if (File.Exists(this.CurrentNotificationSettingsPath + @"\" + _webServerXmlSerilaizationFile))
            {
                this.WebServerSettings =
                    this._xmlSerializerWebserverSettings.Desirialize(this.CurrentNotificationSettingsPath + @"\" +
                                                    _webServerXmlSerilaizationFile);
            }


        }

        /// <summary>
        /// Occurs when [property changed].
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Notfiys the property changed.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        private void NotfiyPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        
        /// <summary>
        /// Gets the web server config template.
        /// </summary>
        /// <returns></returns>
        private string GetWebServerConfigTemplate()
        {
            StringBuilder WebServerConfigTemplate = new StringBuilder();

            WebServerConfigTemplate.Append("local.application.port={0}");
            WebServerConfigTemplate.Append(Environment.NewLine);
            WebServerConfigTemplate.Append("local.application.maxworkerthreadcount=10");
            WebServerConfigTemplate.Append(Environment.NewLine);
            WebServerConfigTemplate.Append("local.filesystemhandler.enabledirectorybrowsing={1}");
            WebServerConfigTemplate.Append(Environment.NewLine);
            WebServerConfigTemplate.Append("local.requestfiltermodule.enabled=true");
            WebServerConfigTemplate.Append(Environment.NewLine);
            WebServerConfigTemplate.Append("local.requestfiltermodule.allowmask=127.0.0.*");
            WebServerConfigTemplate.Append(Environment.NewLine);

            return WebServerConfigTemplate.ToString();
        }

        /// <summary>
        /// Fills the web server config template.
        /// </summary>
        /// <param name="localPort">The local port.</param>
        /// <param name="localPath">The local path.</param>
        /// <param name="enableDirectoryBrowsing">if set to <c>true</c> [enable directory browsing].</param>
        /// <returns></returns>
        private string FillWebServerConfigTemplate(int localPort,bool enableDirectoryBrowsing)
        {

            var template = this.GetWebServerConfigTemplate();

            var filledTemplate = string.Format(template, localPort, enableDirectoryBrowsing);

            return filledTemplate;

        }

        /// <summary>
        /// Saves the web server config to web root.
        /// </summary>
        private void SaveWebServerConfigToWebRoot()
        {
            string fileName = this.CurrentWebRootpath + @"\" + this._webServerConfigFileName;

            string template = this.FillWebServerConfigTemplate(this.WebServerSettings.WebServerPort,
                                                            this.WebServerSettings.EnableDirectoryBrowsing);

            File.WriteAllText(fileName,template);

        }



       



    }
}
