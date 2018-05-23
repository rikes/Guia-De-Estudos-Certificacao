using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncProgram
{
    class Program
    {
        //Não é possível chamar métodos assincronos no Main. 
        static void Main(string[] args)
        {

            MainAsync().Wait();

        }

        static async Task MainAsync()
        {
            var stopwatch = new Stopwatch();
            Exemples exemplo = new Exemples();
            
            stopwatch.Start();
            var result = await exemplo.AccessTheWebAsync();
            

            Console.WriteLine("Var:\n {0}\n\nTempo passado: {1}",result, stopwatch.Elapsed);
            Console.ReadKey();
        }
    }
}
