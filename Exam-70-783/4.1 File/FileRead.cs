using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4._1_File
{
    class FileRead
    {
        //Informar o arquivo com o caminho
        public void Read(string fileWtihPath)
        {
            if (File.Exists(fileWtihPath))
            {
                using (Stream arquivo = File.Open(fileWtihPath, FileMode.Open))
                using (StreamReader leitor = new StreamReader(arquivo))
                {
                    string linha = leitor.ReadLine();
                    while (linha != null)
                    {
                        Console.WriteLine(linha);
                        linha = leitor.ReadLine();
                    }
                }
            }
        }
    }
}
