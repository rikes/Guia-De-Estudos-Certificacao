using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Threading;


namespace _3._4_Breakpoints
{
    class Program
    {
        public static void Main()
        {
            //Timer t = new Timer(TimerCallback, null, 0, 2000);
            Pessoa p = new Pessoa
            {
                FirstName = "Patricia",
                LastName = "Amorim"
            };

            NadaFaz();
            Console.ReadLine();
        }

        private static void TimerCallback(Object o)
        {
            Console.WriteLine("In TimerCallback: " + DateTime.Now);

            #if DEBUG
            Console.WriteLine("modo de depuração");
            #else
            Console.WriteLine ("modo de Release");
            #endif
            

            // 1-2 ; 2-1 ; 3-4
            GC.Collect();
        }

        [Conditional("DEBUG")]
        private static void NadaFaz()
        {
            #pragma warning disable
            while (false)
            {
                Console.WriteLine("Unreachable code");
            }
            #pragma warning restore
        }

        [DebuggerDisplay("Name = {FirstName} {LastName")]
        public class Pessoa
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }
    }
}
