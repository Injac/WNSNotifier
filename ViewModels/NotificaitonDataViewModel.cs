using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Unity;
using WNSNotifier.Notifications;
using WNSNotifier.Services;

namespace WNSNotifier.ViewModels
{
    class NotificaitonDataViewModel:INotifyPropertyChanged
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
        public  ICommand SerializeDataCommand
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
        /// The _notification settings file name
        /// </summary>
        private readonly string _notificationSettingsFileName = "NotificaitonSettings.xml";


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
        /// The _notification data
        /// </summary>
        private NotificationData _notificationData;

        /// <summary>
        /// Gets or sets the _XML serializer.
        /// </summary>
        /// <value>
        /// The _XML serializer.
        /// </value>
        [Dependency]
        private IXmlSerializer<NotificationData> _xmlSerializer { get; set; } 

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
        /// Initializes a new instance of the <see cref="NotificaitonDataViewModel" /> class.
        /// </summary>
        public NotificaitonDataViewModel()
        {
            this.CurrentAssemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            this.NotificationData = new NotificationData();

            if (CurrentAssemblyPath != null)
            {
                this.CurrentNotificationSettingsPath = Path.Combine(CurrentAssemblyPath, "Settings");
            }

            this.SerializeDataCommand = new DelegateCommand(this.SerializeData);
            this.DeserializeCommand = new DelegateCommand(this.DeserializeData);

            //If we have already a file, go and get it!
            this.DeserializeData();
        }


        /// <summary>
        /// Serializes the data.
        /// </summary>
        private void SerializeData()
        {
            this._xmlSerializer.Serialize(this.NotificationData, this.CurrentNotificationSettingsPath + @"\" + _notificationSettingsFileName);
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
            if(this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
