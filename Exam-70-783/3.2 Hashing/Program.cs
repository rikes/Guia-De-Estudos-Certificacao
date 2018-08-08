using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace _3._2_Hashing
{
    /// <summary>
    /// Fazer o uso da 'SHA256Managed', que efetua um cálculo para gerar Hash's de 256 bits
    /// Lembrando que Hash deve ser iguais assim como os dados que os represetam.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Aux.Validador("Primeiro paragrafo",
                          "sEGUNDO paragrafo ",
                          "Primeiro paragrafo");



            Console.ReadKey();
        }
    }


    public class Aux
    {
        public string teste { get; set; }

        public static void Validador(string msgA, string msgB, string msgC)
        {
            UnicodeEncoding byteConverter = new UnicodeEncoding();
            SHA256 sha256 = SHA256.Create();

            byte[] hash = sha256.ComputeHash(Encoding.Default.GetBytes(msgB));

            byte[] hashA = sha256.ComputeHash(byteConverter.GetBytes(msgA));
            
            byte[] hashB = sha256.ComputeHash(byteConverter.GetBytes(msgB));
            
            byte[] hashC = sha256.ComputeHash(byteConverter.GetBytes(msgC));

            Console.WriteLine(hashA.SequenceEqual(hashB) + "\t" + msgA.GetHashCode() + "\t" + msgB.GetHashCode());
            Console.WriteLine(hashA.SequenceEqual(hashC) + "\t" + msgA.GetHashCode() + "\t" + msgC.GetHashCode());
            Console.WriteLine("");
            //Encoding diferente
            Console.WriteLine(hash.SequenceEqual(hashB) + "\t" + hash.GetHashCode() + "\t" + hashB.GetHashCode());


        }
    }
}

