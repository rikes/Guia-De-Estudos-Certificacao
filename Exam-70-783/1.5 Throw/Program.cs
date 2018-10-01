using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._5_Throw
{
    class Program
    {
        /*
         * https://docs.microsoft.com/pt-br/dotnet/csharp/language-reference/keywords/throw
         * Quando você lança apenas um throw está repassando a mesma exceção para frente e,
         * dessa forma, outro trecho de código poderá capturar e saber o que vai fazer com a
         * exceção original retendo todas as informações necessárias com o stack trace.
         */
        static void Main(string[] args)
        {

            var s = new Sentence(null);
            Console.WriteLine($"The first character is {s.GetFirstCharacter()}");
        }



    }
    public class Sentence
    {
        public Sentence(string s)
        {
            Value = s;
        }

        public string Value { get; set; }

        public char GetFirstCharacter()
        {
            try
            {
                return Value[0];
            }
            catch (Exception e)
            {
                throw;//Lança a exceção de origem... 'NullReferenceException'
            }
        }
    }
}
