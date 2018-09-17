using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Security.AccessControl;

namespace _4._1_Streams
{
    class Program
    {
        static void Main(string[] args)
        {

            /*
             * Ele cria o arquivo, e não o diretorio com o arquivo, por isso precisamos veririfacr a existencia
             * Poderiamos usar o objeto da classe FileStream para criarmos o arquivo
             *
             * FileStream fs = new FileStream(@"C:\temp2\numeros.txt", FileMode.Create, FileAccess.Write, FileShare.None);
             */
            string path = @"C:\temp2\numeros.txt";
            if (File.Exists(path))
            {
                using (FileStream fs = File.Create(@"C:\temp2\numeros.txt"))
                {
                    for (int i = 0; i < 10; i++)
                    {
                        byte[] number = new UTF8Encoding(true).GetBytes(i.ToString());
                        fs.Write(number, 0, number.Length);
                    }
                }
            }
        }

    }
}
