using System.Xml.Serialization;

namespace GannettConfigXmlSerializationPlayground
{
    /// <remarks/>
    [XmlType(AnonymousType = true)]
    public class ConfigSetting
    {
        /// <remarks/>
        [XmlElement("add")]
        public Setting[] Settings { get; set; }

        /// <remarks/>
        [XmlAttribute("type")]
        public string Type { get; set; }
    }
}