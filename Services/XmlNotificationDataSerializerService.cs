using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using WNSNotifier.Notifications;

namespace WNSNotifier.Services
{
    /// <summary>
    /// Serialize and deserialize
    /// NotificationsData.
    /// </summary>
    class XmlNotificationDataSerializerService:IXmlSerializer<NotificationData>
    {

        /// <summary>
        /// Serializes the specified object to serialize.
        /// </summary>
        /// <param name="objectToSerialize">The object to serialize.</param>
        /// <param name="outputPath">The output path.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void Serialize(NotificationData objectToSerialize, string outputPath)
        {
            var serializer = new XmlSerializer(typeof(NotificationData));
            TextWriter textWriter = new StreamWriter(outputPath);
            serializer.Serialize(textWriter,objectToSerialize);
            textWriter.Close();
        }

        /// <summary>
        /// Desirializes the specified path to file.
        /// </summary>
        /// <param name="pathToFile">The path to file.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public NotificationData Desirialize(string pathToFile)
        {
            var serializer = new XmlSerializer(typeof(NotificationData));
            TextReader reader = new StreamReader(pathToFile);
            var notificationSettings = serializer.Deserialize(reader) as NotificationData;

            return notificationSettings;
        }
    }
}
