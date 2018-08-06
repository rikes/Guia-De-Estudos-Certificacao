using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;


namespace _3._1_Data_Annotation
{
    class Program
    {
        static void Main(string[] args)
        {
            Cliente cliente = new Cliente();
            Address endereco = new Address();

            endereco.Avenida = "Avenida Brasil";
            endereco.Bairro = "Cobi de Baixo";
            endereco.Cidade = "VV";
            endereco.Numero = 420;
            endereco.ZipCode = "29.115-795";

            cliente.EnderecoDeEnvio = endereco;

            cliente.Idade = 20;
            cliente.Nome = "Henrique";
            cliente.UltimoNome = "Santos";
            cliente.email = "henricke@gmail.com";
            
            var validation = new ValidationContext(cliente,null,null);
            var validation2 = new ValidationContext(endereco, null, null);

            List<ValidationResult> results = new List<ValidationResult>();
            bool valido = Validator.TryValidateObject(cliente, validation, results, true);
            valido = Validator.TryValidateObject(endereco, validation2, results, true);

            if (!valido)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Employee class Validation");
                Console.WriteLine("---------------------------\n");

                foreach (var validacaoResult  in results)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("Atributo: {0}", validacaoResult.MemberNames.First());
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("   ::  {0}", validacaoResult.ErrorMessage);

                }


            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\nPress any key to exit");
            Console.ReadKey();

        }
    }
}
