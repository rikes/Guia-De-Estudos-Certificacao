using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;

namespace _4._2_XmlReader
{
    class Program
    {
        /*
         *
         * ReadStartElement funciona como um ponteiro, devemos seguir elemento a elemento, não é possível pular.
         * Por exemplo, se quisermos apenas o telefone. Devemos passar por todos atributos até chegar no telefone,
         * para só assim ter o value.
         *
         */
        static void Main(string[] args)
        {
            using(XmlReader xmlReader = XmlReader.Create("People.xml", new XmlReaderSettings() { IgnoreWhitespace = true}))
            {
                
                while (xmlReader.)
                {
                    xmlReader.MoveToContent();
                    xmlReader.ReadStartElement("person");

                    string firstname = xmlReader.GetAttribute("firstname");
                    string lastname = xmlReader.GetAttribute("lastname");

                    Console.WriteLine("Person: {0} {1}", firstname, lastname);
                    xmlReader.ReadStartElement("person");

                    Console.WriteLine("Contact Details");

                    xmlReader.ReadStartElement("contactdetails");
                    xmlReader.ReadStartElement("email");

                    string email = xmlReader.Value;
                    //xmlReader.ReadStartElement("phone");// xmlReader.GetAttribute("telefone");  
                    string telefone = xmlReader.GetAttribute("phone"); ;
                    //string telefone = xmlReader.Value;

                    Console.WriteLine("Telefone : {0}", telefone);
                    Console.WriteLine("Email address: {0}", email);
                }

            }
            Console.ReadLine();
        }
    }
}
