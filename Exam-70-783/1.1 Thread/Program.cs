using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _1._1_Thread
{
    class Program
    {
        static void Main(string[] args)
        {

            //Especifique um metodo ou um delegate....
            Thread t = new Thread(metodoParaThread);
            t.Start();

            for (int i = 0; i < 1000; i++)
            {
                Console.Write("O");

                /*
                 * Suspende uma thread atual em um curto período de tempo. Usamos o '0' para demonstrar que já concluímos o
                 * que queríamos executar a principio aqui. No caso imprimir uma mensagem.
                 */
                Thread.Sleep(0); 
            }
            

            
            t.Join();//Quando uma thread suspente a execução (sleep). É 'necessário' invocar o Join para 'Aguardar' os resultados.
            Console.ReadLine();
        }
        
        static void metodoParaThread()
        {

            for (int i = 0; i < 1000; i++)
            {
                Console.Write(".");
                Thread.Sleep(0);
            }

        }
    }
}
