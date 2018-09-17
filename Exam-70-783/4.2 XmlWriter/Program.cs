using System;
using System.IO;
using System.Xml;

namespace _4._2_XmlWriter
{
    class Program
    {
        static void Main(string[] args)
        {
            
            /*
             * StringWriter permite que você gravar em uma cadeia de caracteres, de forma síncrona ou assíncrona. Você pode escrever um caractere por vez com o Write(Char) ou o WriteAsync(Char) método, uma cadeia de caracteres em uma hora usando o Write(String) ou o WriteAsync(String) método.
             */
            StringWriter stream = new StringWriter();

            using(XmlWriter writer = XmlWriter.Create(stream, new XmlWriterSettings(){Indent = true}))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("people");
                writer.WriteStartElement("person");
                writer.WriteAttributeString("firstname", "john");
                writer.WriteAttributeString("lastname", "silva");
                writer.WriteStartElement("contactdetails");
                writer.WriteElementString("emailaddress", "john@john.com");
                //writer.WriteEndElement();
                //writer.WriteEndElement();
                //writer.WriteEndElement();
                writer.Flush();
            }

            Console.WriteLine(stream.ToString());
            Console.ReadLine();
        }
    }
}
