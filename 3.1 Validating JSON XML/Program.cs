using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Xml;
using System.Xml.Schema;

namespace _3._1_Validating_JSON_XML
{
    class Program
    {
        static void Main(string[] args)
        {
            var serializer = new JavaScriptSerializer();
            //Validador de Json
            var resultJson = serializer.Deserialize<Dictionary<string, object>>(Aux.Json());

            //Validador de Xml
            Aux.ValidateXML();

            //List<string> list = new List<string>(resultJson.Keys);
            //List<string> list2 = new List<string>(resultXml.Keys);
            Console.WriteLine(resultJson.Keys.Count);
            

            Console.ReadKey();
        }
    }

    public class Aux
    {
        //Classe que retorna um json
        public static string Json()
        {
            return @"{""menu"": {
  ""id"": ""file"",
  ""value"": ""File"",
  ""popup"": {
    ""menuitem"": [
      {""value"": ""New"", ""onclick"": ""CreateNewDoc()""},
      {""value"": ""Open"", ""onclick"": ""OpenDoc()""},
      {""value"": ""Close"", ""onclick"": ""CloseDoc()""}
    ]
  }
}}";

        }

        //Classe que retorna um Xml
        //public static string Xml()
        //{
        //    string path = @"..\..\XML.xml";

        //    return File.ReadAllText(path);
        //}
        public static void ValidateXML()
        {
            XmlReader reader = XmlReader.Create(@"..\..\XML.xml");
            XmlDocument document = new XmlDocument();
            document.Schemas.Add("", @"..\..\XML.xsd");
            document.Load(reader);

            ValidationEventHandler eventHandler = new ValidationEventHandler(ValidationEventHandler);
            document.Validate(eventHandler);

            Console.WriteLine(document.Name);
            Console.WriteLine(document.BaseURI);
        }

        static void ValidationEventHandler(object sender,
            ValidationEventArgs e)
        {
            switch (e.Severity)
            {
                case XmlSeverityType.Error:
                    Console.WriteLine("Error: {0}", e.Message);
                    break;
                case XmlSeverityType.Warning:
                    Console.WriteLine("Warning {0}", e.Message);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }


    }
}
