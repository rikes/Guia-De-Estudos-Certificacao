using System;
using System.Diagnostics;
using System.IO;

namespace _3._5_Diagnostic_App
{
    class Program
    {
        static void Main(string[] args)
        {
            TraceClass();
            Console.ReadLine();
        }
        
        /*
         * Debug assert é utilizado para verificarmos uma condição. Podemos apontar indicar esse ponto caso não seja atendido
         */
        public static void DebugClass()
        {
            Debug.WriteLine("Starting application");
            Debug.Indent();
            int i = 1 + 2;
            Debug.Assert(i != 3);
            Debug.WriteLineIf(i > 0, "i is greater than 0");
        }


        public static void TraceClass()
        {
            //Inicia umTraceSource que exibira, conforme o enum 'SourceLevels' as informacoes destinadas a ele
            //Na saida do visual Studio
            TraceSource traceSource = new TraceSource("Trace", SourceLevels.All);

            traceSource.TraceInformation("Tracing application..");//'SourceLevels' informativo
            traceSource.TraceEvent(TraceEventType.Critical, 0, "Critical trace");//'SourceLevels' Critical
            traceSource.TraceData(TraceEventType.Error, 1, new object[] { "a", "b", "c" });//'SourceLevels' informativo

            //WriteTrace("Tracing application..", TraceEventType.Information);
            //WriteTrace("Critical trace!!!!..", TraceEventType.Critical);
            //WriteTrace("Error 404..??..", TraceEventType.Error);
            Stream myFile = File.Create(@"..\\..\\Log\\LogTrace.txt");

            WriteTraceInFile(myFile,"Tracing App Info", TraceEventType.Information);
            WriteTraceInFile(myFile, "Tracing App Info", TraceEventType.Critical);

            myFile.Close();


            System.Diagnostics.Debug.WriteLine("Hello World!");//Exibe através da classe 'Debug', se estivermos em modo debug

            traceSource.Flush();
            traceSource.Close();
        }
        /*
         * Queria ter feito um metodo que recebece o TraceSource e grave em um arquivo
         * Mas deu para entender como gravar em um arquivo
         * Obs.: Código desse 'cs' totalmente fora dos padrões de programação.
         */
        public static void WriteTraceInFile(Stream myFile, string msg, TraceEventType? typeTrace)
        {
            // Create a file for output named LogTrace.txt.
            //Stream myFile = File.Create(@"..\\..\\Log\\LogTrace.txt");
            Trace.AutoFlush = true;//Libera o conteudo automaticamente

            /* Create a new text writer using the output stream, and add it to
             * the trace listeners.
             */
            TextWriterTraceListener myTextListener = new TextWriterTraceListener(myFile);
            Trace.Listeners.Add(myTextListener);

            //Trace.Listeners.AddRange(traceSource.Listeners);


            //Trace.WriteLine(string.Format("{0:G} -",DateTime.Now));

            switch (typeTrace)
            {
                case TraceEventType.Information:
                    Trace.TraceInformation(msg);
                    break;
                case TraceEventType.Critical:
                    Trace.TraceWarning(msg);
                    break;
                case TraceEventType.Error:
                    Trace.TraceError(msg);
                    break;
            }
            // Flush the output.
            Trace.Flush();

        }


    }
}
