using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WNSNotifier.Services
{
    /// <summary>
    /// Serialize any type of object.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    interface IXmlSerializer<T>
    {

        /// <summary>
        /// Serializes the specified object to serialize.
        /// </summary>
        /// <param name="objectToSerialize">The object to serialize.</param>
        /// <param name="outputPath">The output path.</param>
        void Serialize(T objectToSerialize, string outputPath);

        /// <summary>
        /// Desirializes the specified path to file.
        /// </summary>
        /// <param name="pathToFile">The path to file.</param>
        /// <returns></returns>
        T Desirialize(string pathToFile);


    }
}
