using System.Xml.Serialization;

namespace GannettConfigXmlSerializationPlayground
{
    /// <remarks/>
    [XmlType(AnonymousType = true)]
    [XmlRoot(ElementName = "config", Namespace = "", IsNullable = false)]
    public class Config
    {
        /// <remarks/>
        [XmlArrayItem("setting", IsNullable = false)]
        public ConfigSetting ConfigSettings { get; set; }

    }
}