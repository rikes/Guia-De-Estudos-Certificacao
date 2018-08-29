using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._2_Operrator_Explicit_Implicit
{
    class Program
    {
        static void Main(string[] args)
        {
            Money m = new Money(42.42M);

            //Invoca o operador implicito 'decimal'
            decimal amount = m;
            //Invoca o operador implicito 'string'
            string s = m;
            //Invoca o operador implicito 'int'
            int truncatedAmount = m;

            Console.WriteLine("\n {0} \t {1} \t {2}", m.Amount, truncatedAmount, s);
            //Invoca o operador explicito 'Money(string)'
            try
            {
                string valorString = "10,55";

                Money mm = (Money)valorString;
                Console.WriteLine("Valor Explicito {0}", mm.Amount);
            }
            catch (FormatException Fe)
            {
                Console.WriteLine("Erro {0}", Fe.Message);
            }

            //'is' and 'as'
            object[] objArray = new object[6];
            objArray[0] = "Texto";
            objArray[1] = 33;
            if (objArray[0] is string)
            {
                Console.WriteLine("É String");
            }
            //as executa somente conversões de referência, conversões que permitem valor nulo e conversões boxing
            //Não faz conversoes definidas pelo usuario
            //Ele atrabui o valor a uma variavel ou seta nulo se o tipo for diferente
            string text = objArray[0] as string;
            string number = objArray[1] as string;

            Console.WriteLine("Text: {0} \nNumber {1}", text, number);

            Console.ReadLine();
        }
    }
}
