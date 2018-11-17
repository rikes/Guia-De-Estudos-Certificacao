using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Runtime.Serialization.Json;

namespace _4._4_JSON_serialization
{
    class Program
    {
        static void Main(string[] args)
        {
            UpdateJson update = new UpdateJson();

            update.RemoveCarcter();


            //Lembrando que o Id e Desc nao sera serializado/salvo
            /*Product prod = new Product
            {
                id = 3,
                name = "Kit Kat",
                price = 2.50m,
                desc = "Meio Amargo"
            };

            if (prod.id.HasValue)
            {
                Console.WriteLine("Tem valor!!!!");
            }

            // Serialize
            //Sera salvo na pasta /bin/Debug
            Stream stream = new FileStream("Product.json", FileMode.Create);
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Product));
            ser.WriteObject(stream, prod); // Note: call WriteObject method instead of Serialize
            stream.Close();

            // Deserialize
            Product prod2 = new Product();
            Stream stream2 = new FileStream("Product.json", FileMode.Open);
            DataContractJsonSerializer ser2 = new DataContractJsonSerializer(typeof(Product));
            prod2 = (Product)ser.ReadObject(stream2); // Note: call ReadObject method instead of Deserialize
            stream2.Close();


            Console.WriteLine("Id: {0} \nName: {1} \nprice {2:C} \nDesc {3}", prod2.id, prod2.name, prod2.price, prod2.desc);
            */
            Console.ReadLine();
        }
    }
}
