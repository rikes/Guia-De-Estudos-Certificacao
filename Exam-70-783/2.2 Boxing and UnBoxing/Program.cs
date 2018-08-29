using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace _2._2_Boxing_and_UnBoxing
{
    class Program
    {
        static void Main(string[] args)
        {
            var p = string.Concat("To Box ou no box\t", 42 + "\t", true);

            //Boxing int
            int i = 42;
            object o = i;
            int x = (int)o;

            Console.WriteLine(p + "\n" + x);
            HttpClient client = new HttpClient();
            object oc = client;
            IDisposable d = client;

            Console.WriteLine("\n {0} \t {1}", oc.GetHashCode(), d.GetHashCode());

            Console.ReadKey();

        }
    }
}
