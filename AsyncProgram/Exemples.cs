using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AsyncProgram
{
    class Exemples
    {

        //Metodo Assincrono que possui como retorno uma tarefa do tipo Int
        public async Task<int> AccessTheWebAsync()
        {
            // Declaramos HttpClient para obtermos dados da web
            HttpClient client = new HttpClient();

            // GetStringAsync retorna uma Task<string>. 
            // Isso significa que você obterá em algum momento... uma string (urlContents).  
            Task<string> getStringTask = client.GetStringAsync("http://msdn.microsoft.com");

            //Exibe aguardando sem depender do resultado de GeStringAsync
            Console.WriteLine("Aguardando....");

            //Aguardo a requisição de GetStringAsync por completo. 
            string urlContents = await getStringTask;
            
            //Especifico o que desejo retornar
            return urlContents.Length;
        }

    }
}
