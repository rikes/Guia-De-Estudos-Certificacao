using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._1_Generics
{
    class Program
    {
        static void Main(string[] args)
        {
            GenericItems<int> genericInts = new GenericItems<int>();
            genericInts.Add(50);
            genericInts.Add(33);

            Console.WriteLine(genericInts[1]);
            
            GenericItems<double> genericDouble = new GenericItems<double>();
            genericDouble.Add(22.3d);
            genericDouble.Add(0.3d);

            Console.WriteLine(genericDouble[0] + "\t" + genericDouble[1]);

            GenericItems<DateTime> genericDatetime = new GenericItems<DateTime>();
            genericDatetime.Add(new DateTime());
            genericDatetime.Add(DateTime.Now);
            genericDatetime.Add(DateTime.MaxValue);

            Console.WriteLine(genericDatetime[0] + "\t" + genericDatetime[1] + "\t" + genericDatetime[2]);

            
            //GenericItems<string> genericStr = new GenericItems<string>();
            //genericStr.Add("Brett");
            //genericStr.Add("Rules!!!");
            //Console.WriteLine(genericStr[0] + " " + genericStr[1]);


            Console.ReadLine();
        }
    }
}
