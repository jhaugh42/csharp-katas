using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SerializationDemo
{

    [Serializable]
    [XmlType(AnonymousType = false, TypeName = "Asset")]
    [XmlRoot("asset", Namespace = "", IsNullable = false)]
    public class Asset
    {
        private List<Item> _attributes = new List<Item>();
        private Attributes _attributesDictionary = new Attributes();

        [XmlArray("attributes")]
        [XmlArrayItem("item")]
        public List<Item> Attributes
        {
            get { return _attributes; }
            set { _attributes = value; }
        }

        [XmlElement("attributesDictionary")]
        public Attributes AttributesDictionary
        {
            get { return _attributesDictionary; }
            set { _attributesDictionary = value; }
        }
    }
}
