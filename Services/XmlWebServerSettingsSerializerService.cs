using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using WNSNotifier.Notifications;
using WNSNotifier.WebServer;

namespace WNSNotifier.Services
{
    /// <summary>
    /// Serialize and deserialize
    /// WebServerSettings date.
    /// </summary>
    class XmlWebServerSettingsSerializerService : IXmlSerializer<WebServerSettings>
    {

        /// <summary>
        /// Serializes the specified object to serialize.
        /// </summary>
        /// <param name="objectToSerialize">The object to serialize.</param>
        /// <param name="outputPath">The output path.</param>
        public void Serialize(WebServerSettings objectToSerialize, string outputPath)
        {
            var serializer = new XmlSerializer(typeof(WebServerSettings));
            TextWriter textWriter = new StreamWriter(outputPath);
            serializer.Serialize(textWriter, objectToSerialize);
            textWriter.Close();
        }


        /// <summary>
        /// Desirializes the specified path to file.
        /// </summary>
        /// <param name="pathToFile">The path to file.</param>
        /// <returns></returns>
        public WebServerSettings Desirialize(string pathToFile)
        {
            var serializer = new XmlSerializer(typeof(WebServerSettings));
            TextReader reader = new StreamReader(pathToFile);
            var notificationSettings = serializer.Deserialize(reader) as WebServerSettings;

            return notificationSettings;
        }

    
    }
}
