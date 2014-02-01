using System;
using System.Xml.Serialization;

namespace SerializationDemo
{
    [Serializable]
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false)]
    public class Item
    {
        public Item()
        {
            Value = "";
        }

        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("value")]
        public string Value { get; set; }
    }
}