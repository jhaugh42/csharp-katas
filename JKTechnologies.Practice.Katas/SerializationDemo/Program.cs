using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace SerializationDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Asset asset = new Asset();

            asset.Attributes.Add(new Item { Name = "this is my name", Value = "this is my value" });
            asset.AttributesDictionary["this is my name"] = "this is my value";

            File.WriteAllText(@"e:\testSerialization.txt", SerializeToString(asset), Encoding.UTF8);

            Asset fromFile = Deserialize<Asset>(File.ReadAllText(@"e:\testSerialization.txt", Encoding.UTF8));

            Console.WriteLine(SerializeToString(asset));
            Console.WriteLine(SerializeToString(fromFile));

            Console.ReadLine();
        }

        static T Deserialize<T>(string serializedThingy)
        {
            UTF8Encoding encoding = new UTF8Encoding();
            byte[] bytesOfThing = encoding.GetBytes(serializedThingy);

            using (MemoryStream memoryStream = new MemoryStream(bytesOfThing))
            {
                XmlSerializer xs = new XmlSerializer(typeof(T));
                return (T)xs.Deserialize(memoryStream);
            }
        }


        static string SerializeToString<T>(T o)
        {
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("", "");
            XmlSerializer serializer = new XmlSerializer(o.GetType());
            XmlWriterSettings writerSettings = new XmlWriterSettings();
            writerSettings.OmitXmlDeclaration = true;
            StringWriter stringWriter = new StringWriter();

            using (XmlWriter xmlWriter = XmlWriter.Create(stringWriter, writerSettings))
            {
                serializer.Serialize(xmlWriter, o, ns);
                return stringWriter.ToString();
            }
        }

    }




}
