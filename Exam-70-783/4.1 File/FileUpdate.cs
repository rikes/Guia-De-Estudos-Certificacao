using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4._1_File
{
    class FileUpdate
    {
        /// <summary>
        /// Este método lê um arquivo buscando numeros de tamanho 7 e removendo o último caracter deste número
        /// ex.: 3200102 -> 3200102
        /// É importante validar se o próximo caracter do último número é branco
        /// </summary>
        /// <param name="arquivo"></param>
        public void updateNumber(string arquivo)
        {
            //FileMode.Append mantem os dados e incrementa.
            if (File.Exists(arquivo))
            {





                using (Stream stream = File.OpenWrite(arquivo))
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    
                }
            }
        }


        public string RemoverAcentuacao(string text)
        {
            return new string(text
                .Normalize(NormalizationForm.FormD)
                .Where(ch => char.GetUnicodeCategory(ch) != UnicodeCategory.NonSpacingMark)
                .ToArray());
        }
    }
}
