using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace SerializationDemo
{
    public class Attributes : Dictionary<string, string>, IXmlSerializable
    {
        public XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            if (reader.IsEmptyElement) return;

            reader.ReadStartElement("attributesDictionary");
            while (reader.NodeType != XmlNodeType.EndElement)
            {
                string key = reader.GetAttribute("name");
                string value = reader.GetAttribute("value");
                
                if (string.IsNullOrEmpty(key))
                {
                    throw new InvalidOperationException("Unable to deserialize attribute dictionary because a null or empty key was encoutered.  This should never happen but if it does this means the XML we are dealing with is bad.");
                }
                
                this[key] = value;
                reader.Read();
            }
            reader.ReadEndElement();
        }

        public void WriteXml(XmlWriter writer)
        {
            foreach (var key in Keys)
            {
                writer.WriteStartElement("item");
                writer.WriteAttributeString("name", key);
                writer.WriteAttributeString("value", this[key]);
                writer.WriteEndElement();
            }
        }
    }
}
