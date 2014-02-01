using System.Xml.Serialization;

namespace GannettConfigXmlSerializationPlayground
{
    /// <remarks/>
    [XmlType(AnonymousType = true)]
    public class Setting
    {
        /// <remarks/>
        [XmlAttribute("key")]
        public string Key { get; set; }

        /// <remarks/>
        [XmlAttribute("value")]
        public string Value { get; set; }
    }
}