using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._1_TryParse
{
    class Program
    {
        static void Main(string[] args)
        {
            //Parse - Lança exceção
            string value = "true";
            bool b = bool.Parse(value);
            Console.WriteLine(b); // displays True

            //TryParse - Não lança exceção = Recomendavel para tratar entradas do usuario
            string value2 = "1";
            int result;
            bool success = int.TryParse(value2, out result);
            //bool success = int.TryParse(null, out result);

            if (success)
            {
                Console.WriteLine("é um Inteiro");
            }
            else
            {
                Console.WriteLine("Não é inteiro");
            }

            //Convert pode converter tipos Bases. Diferente de Parse ele nao lança um ArgumentNullException ao tentar converter nulo
            int i = Convert.ToInt32(null);
            Console.WriteLine(i); // Displays 0


            double d = 23.15;
            int inteiro = Convert.ToInt32(d);
            Console.WriteLine(inteiro); // Displays 23


            Console.ReadKey();

        }
    }
}
