using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _3._1_Regular_Expression
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Aux.ValidateZipCodeRegEx("29117795"));
            Console.WriteLine(Aux.ValidateZipCodeRegEx("29117-795"));
            Console.WriteLine(Aux.ValidateZipCodeRegEx("29117.795"));
            Console.WriteLine(Aux.ValidateZipCodeRegEx("291795"));
            Console.WriteLine(Aux.ValidateZipCodeRegEx("29.117-795"));

            
            Console.WriteLine(Aux.RemoveMultipleSpace("1 2 3 4  5"));
            Console.WriteLine(Aux.RemoveMultipleSpace("  1     2 3 4      5"));

            Console.ReadKey();
        }
    }


    public class Aux
    {
        public static bool ValidateZipCodeRegEx(string zipCode)
        {
            Match match = Regex.Match(zipCode, @"[0-9]{2}\.?[0-9]{3}\-?[0-9]{3}", RegexOptions.IgnoreCase);
            return match.Success;
        }

        public static string RemoveMultipleSpace(string input)
        {
            RegexOptions options = RegexOptions.None;
            Regex regex = new Regex(@"[ ]{2,}", options);

            return regex.Replace(input, " ");

        }

    }
}
