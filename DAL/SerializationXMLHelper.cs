using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace Joar_HC_ModernRealEstates
{

    public static class SerializationHelper
    {
        public static void SerializeToXml<T>(T obj, string filePath, XmlAttributeOverrides overrides = null)
        {
            using (var writer = new StreamWriter(filePath))
            {
                var serializer = (overrides != null)
                    ? new XmlSerializer(typeof(T), overrides)
                    : new XmlSerializer(typeof(T));

                serializer.Serialize(writer, obj);
            }
        }
    }
}
