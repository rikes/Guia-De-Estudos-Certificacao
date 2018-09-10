using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Reflection;

namespace _2._5_Reflection
{
    class Program
    {
        static void Main(string[] args)
        {
            // A ideia eh fazer um sisteminha de log, na qual independente da classe informada parametro conseguiremos obter informações
            // sobre a classe. Perceba que a classe equipamento tem um campo a mais se comparado a outras duas classes
            Dog dog = new Dog(8, "Bidu");
            Pessoa pessoa = new Pessoa(28,"Henrique Santana");
            Equipamento eqp = new Equipamento(4,"Furadeira","Furadeira com função parafusadeira reversivel");

            //Exibir informações das classes criadas;
            Log(dog);
            Log(pessoa);
            Log(eqp);


            Console.ReadLine();
        }

        public static void Log(object pParametro)
        {
            var tipo = pParametro.GetType();
            var log = new StringBuilder();

            log.AppendLine("Data: " + DateTime.Now);

            //Usamos GetProperties que obter todas as propriedades publicas do objeto
            foreach (var item in tipo.GetProperties())
            {
                //Obtemos o nome que foi definido o atributo/propriedade
                //Pegamos o valor desse atributo informando a INSTANCIA do nosso objeto
                log.AppendLine(item.Name + ": " + item.GetValue(pParametro));
            }

            Console.WriteLine(log);

        }
    }
    
    internal class Dog
    {
        public int Idade { get; set; }
        public string Nome { get; set; }
        
        public Dog(int pIdade, string pNome)
        {
            this.Idade = pIdade;
            this.Nome = pNome;
        }
    }

    internal class Pessoa
    {
        public int Idade { get; set; }
        public string Nome { get; set; }

        public Pessoa(int pIdade, string pNome)
        {
            this.Idade = pIdade;
            this.Nome = pNome;
        }
    }

    internal class Equipamento
    {
        public int Idade { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

        public Equipamento(int pIdade, string pNome, string pDescricao)
        {
            this.Idade = pIdade;
            this.Nome = pNome;
            this.Descricao = pDescricao;
        }
    }
}
