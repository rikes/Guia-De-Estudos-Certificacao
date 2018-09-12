using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _2._6_IDisposable
{
    //https://docs.microsoft.com/pt-br/dotnet/standard/garbage-collection/implementing-dispose
    class OpenFile : IDisposable
    {
        public FileStream stream { get; private set; }

        // Construtor
        public OpenFile(string path)
        {
            this.stream = File.Open(path, FileMode.Open);
        }

        // Destruidor (~)
        /*
         * '~' é a sintaxe de destruidor do C#
         * Esse destrutor só será executado se o método Dispose não é chamado.
         * Dá a sua classe base a oportunidade de finalizar.
         */
        ~OpenFile()
        {
            Dispose(false);
        }

        public void Close()
        {
            Dispose();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        //Libera os recursos
        public void Dispose(bool disposing)
        {
            if(disposing)
            {
                if(stream != null)
                {
                    stream.Close();
                }
            }
        }
    }
}
