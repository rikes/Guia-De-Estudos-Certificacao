using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._1_Extension_Methods
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = 100;
            int answer1 = num1.Add100();

            Console.WriteLine("Half: {0}, Add100: {1}", num1.Half(), num1.Add100());
            Console.ReadLine();
        }
    }
}
