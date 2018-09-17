using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4._1_File
{
    class FileWrite
    {
        //Informar o arquivo com o caminho
        public void Write(string arquivo, string textoParaGravacao)
        {
            //FileMode.Append mantem os dados e incrementa.
            if (File.Exists(arquivo))
            {
                using (Stream stream = File.Open(arquivo, FileMode.Create))
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    writer.WriteLine("\n {0}",textoParaGravacao);
                    writer.Write("\t Incremental");
                }
            }
        }

    }
}
