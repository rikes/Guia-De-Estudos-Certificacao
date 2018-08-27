using System;
using System.Diagnostics;

namespace _3._5_Perfomance_Counter
{
    /*
     * PerfomanceCounter é classe responsável pela análise de desempenho do sistema
     * Neste exemplo analisaremos a quantidade de memória disponível.
     * Podemos conferir informações disponíveis no 'Monitor de Desempenho' do Windos.
     */
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press escape key to stop");
            using (PerformanceCounter pc = new PerformanceCounter("Memory", "Available MBytes"))
            {
                string text = "\t Memória MB Disponível";
                Console.WriteLine(text);
                do
                {
                    while (!Console.KeyAvailable)
                    {
                        Console.Write(pc.RawValue);
                        Console.SetCursorPosition(text.Length, Console.CursorTop);
                    }
                } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
            }
        }
    }
}
