using System;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace Ranges_examples.Classes
{
    public class JSonHelper
    {
        /// <summary>
        /// Convert json string to T
        /// </summary>
        /// <typeparam name="T">Object type</typeparam>
        /// <param name="jsonString">Valid json string</param>
        /// <returns>Instance of T</returns>
        public static T ConvertJSonToObject<T>(string jsonString)
        {
            var serializer = new DataContractJsonSerializer(typeof(T));
            var ms = new MemoryStream(Encoding.UTF8.GetBytes(jsonString));
            T item = (T)serializer.ReadObject(ms);
            return item;
        }

    }
}