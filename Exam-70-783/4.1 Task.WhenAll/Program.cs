using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.IO;
using System.Diagnostics;
using System.Threading;

namespace _4._1_Task.WhenAll
{
    class Program
    {
        static void Main(string[] args)
        {
            string nomeArquivo = @"C:\Temp2\async.txt";

            //CreateAndWriteAsyncFile(nomeArquivo);
            //Console.WriteLine(ReadAsyncHttpRequest().Result);
            Stopwatch sw = new Stopwatch();
            sw.Start();

            Console.WriteLine(ExecuteMultipleRequestsInParallel().Result);

            sw.Stop();
            Console.WriteLine("Time elapsed: " + sw.Elapsed.TotalSeconds);

            Console.ReadLine();

        }

        public static async Task CreateAndWriteAsyncFile(string nomeArquivo)
        {
            if (File.Exists(nomeArquivo))
            {
                Console.WriteLine("Arquivo existe");
                //O construtor de *FileStream*, está passando o nome do arquivo, o que faremos com o arqivo no caso criar, o tipo de acesso, se o arquivo será
                //compartilhado, o tamanho do buffer e por último se será *assincrono*
                using (FileStream fileStream = new FileStream(nomeArquivo, FileMode.Create, FileAccess.Write, FileShare.None, 4096, true))
                {
                    byte[] data = new byte[1000];
                    new Random().NextBytes(data);

                    await fileStream.WriteAsync(data, 0, data.Length);
                }
            }
        }

        public static async Task<string[]> ReadAsyncFile(string nomeArquivo)
        {
            if (File.Exists(nomeArquivo))
            {
                Console.WriteLine("Arquivo existe");
                var lines = new List<string>();
                //O construtor de *FileStream*, está passando o nome do arquivo, o que faremos com o arqivo no caso criar, o tipo de acesso, se o arquivo será
                //compartilhado, o tamanho do buffer e por último se será *assincrono*
                using (FileStream fileStream = new FileStream(nomeArquivo, FileMode.Open, FileAccess.Read, FileShare.None, 4096, true))
                using (var reader = new StreamReader(fileStream, Encoding.UTF8))
                {
                    string line;
                    while ((line = await reader.ReadLineAsync()) != null)
                    {
                        lines.Add(line);
                    }

                    return lines.ToArray();
                }
            }

            return null;
        }

        public static async Task<string> ReadAsyncHttpRequest()
        {
            HttpClient client = new HttpClient();
            return await client.GetStringAsync("http://www.google.com.br");
        }


        public static async Task<string> ExecuteMultipleRequestsInParallel()
        {
            
            HttpClient client = new HttpClient();

            Task<string> google = client.GetStringAsync("http://www.google.com");
            Task<string> msdn = client.GetStringAsync("http://msdn.microsoft.com");
            Task<string> blogs = client.GetStringAsync("http://blogs.msdn.com/");
            Task<string> globoesporte = client.GetStringAsync("https://globoesporte.globo.com");

            await Task.WhenAll(google, msdn, blogs, globoesporte);
            //return true;

            return google.Result + msdn.Result + blogs.Result + globoesporte.Result;
        }

    }
}
