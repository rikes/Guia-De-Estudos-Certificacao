using System;

using System.IO;
using System.Xml.Serialization;

namespace _4._4_XML_serialization
{
    class Program
    {
        static void Main(string[] args)
        {
            //Lembrando que o Id e Desc nao sera serializado/salvo
            Product prod = new Product
            {
                id = 1,
                name = "Fita 3M",
                price = 8.95m,
                desc = "Dupla face"
            };

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Product));
            
            // Serialize
            //Sera salvo na pasta /bin/Debug
            StreamWriter streamWriter = new StreamWriter("Product.xml");
            xmlSerializer.Serialize(streamWriter, prod);
            streamWriter.Close();

            // Deserialize
            FileStream fs = new FileStream("Product.xml", FileMode.Open, FileAccess.Read, FileShare.Read);
            Product prod2 = (Product)xmlSerializer.Deserialize(fs);

            Console.WriteLine("Id: {0} \nName: {1} \nprice {2:C}", prod2.id, prod2.name, prod2.price);
            Console.ReadKey();

        }
    }
}
