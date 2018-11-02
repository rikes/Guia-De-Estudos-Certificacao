using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _4._1_File
{
    class Program
    {
        static void Main(string[] args)
        {
            FileRead fileRead = new FileRead();
            FileWrite fileWrite = new FileWrite();

            //fileRead.Read(@"C:\Temp2\read.txt");
            //fileWrite.Write(@"C:\Temp2\write.txt", "New text oh boy!!! \n Tribufu3");

            string texto =
                "AFONSO CLÁUDIO                                             3200102 ÁGUIA BRANCA                                               3200136 ÁGUA DOCE DO NORTE                                         3200169 ALEGRE                                                      3200201 ALFREDO CHAVES                                              3200300 ALTO RIO NOVO                                               3200359 ANCHIETA                                                    3200409 APIACÁ                                                     3200508 ARACRUZ                                                     3200607 ATILIO VIVACQUA                                             3200706 BAIXO GUANDU                                                3200805 BARRA DE SÃO FRANCISCO                                     3200904 BOA ESPERANÇA                                              3201001 BOM JESUS DO NORTE                                          3201100 BREJETUBA                                                   3201159 CACHOEIRO DE ITAPEMIRIM                                     3201209 CARIACICA                                                   3201308 CASTELO                                                     3201407 COLATINA                                                    3201506 CONCEIÇÃO DA BARRA                                        3201605 CONCEIÇÃO DO CASTELO                                      3201704 DIVINO DE SÃO LOURENÇO                                    3201803 DOMINGOS MARTINS                                            3201902 DORES DO RIO PRETO                                          3202009 ECOPORANGA                                                  3202108 ";


            string teste0 = "3200169 ALEGRE";
            string teste1 = "9200169 ";

            //regex = ^\d+[ ]$ - Nuimeros 0-9 seguido de UM espaço com inicio  \d+[ ]$
            //\d+[ ]
            bool pri = Regex.IsMatch(teste0, @"^\d+[ ]");
            bool sec = Regex.IsMatch(teste1, @"^\d+[ ]");
            bool full = Regex.IsMatch(texto, @"\d+[ ]");


            //string[] numbers = texto.Where(Regex.IsMatch())

            var matches = Regex.Matches(texto, @"\d+[ ]");

            foreach (Match item in matches)
            {
                
                Console.WriteLine("Found '{0}' at position {1}", item.Value, item.Index);

                //Pega o item que foi encontrado, busca no arquivo e substitui por um editado.
                //Abrir arquivo
                //Buscar item encontrado
                //Substituir pelo novo valor. como??
                
            }
            //Salvar arquivo

            Console.ReadLine();


        }
    }
}
