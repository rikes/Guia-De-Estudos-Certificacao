using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._4_IEnumerable
{
    class Program
    {
        static void Main(string[] args)
        {
            Team[] teamArray = new Team[5]
            {
                new Team("Eels"),
                new Team("Sharks"),
                new Team("Roosters"),
                new Team("Cowboys"),
                new Team("Storm")
            };

            NRLTeams teams = new NRLTeams(teamArray);
            foreach(Team t in teams)
            {
                Console.WriteLine(t.name);
            }

            //MoveNext() returna 'true' se houver novos elementos e 'false' caso não haja
            //'Current' seria o objeto atual,´o tipo já se sabe(no caso string), pois foi definido no Using
            //A função GetEnumerator em um IEnumerable retorna um IEnumerator .
            List<string> numbers = new List<string> { "1", "2", "3", "5", "7", "9" };
            using (List<string>.Enumerator enumerator = numbers.GetEnumerator())
            {
                while (enumerator.MoveNext())
                    Console.WriteLine(enumerator.Current);
            }
            Pessoa[] pessoaArray = new Pessoa[3];
            pessoaArray[0] = new Pessoa("Joao", "Amoedo");
            pessoaArray[1] = new Pessoa("Bolso", "Minion");
            pessoaArray[2] = new Pessoa("Marina", "Silva");

            Pessoas pessoas = new Pessoas(pessoaArray);

            Animal a1 = new Animal("Bidu","POoodle");
            Animal a2 = new Animal("Manu", "Pincher");
            Animal a3 = new Animal("Izaq", "Pastor");

            
            //Percorrendo Cada pessoa e exibindo seu toString
            //Como foi implementa em Pessoas a interface de Ienumerable podemos iterar em um VETOR
            foreach (var p in pessoas)
            {
                Console.WriteLine(p.ToString());
            }

            /* Animals não herda de Ienumrable, o que não permite a iteracao na lista.
             *
             */
            //foreach (var a in Animals)
            //{
                
            //}

            Console.ReadLine();
        }
    }
}

class Animal
{
    public Animal(string nome, string raca)
    {
        Nome = nome;
        Raca = raca;
    }

    public string Nome { get; set; }
    public string Raca { get; set; }

    public override string ToString()
    {
        return Nome + "\t" + Raca;
    }
}

class Animals
{
    public Animals(Animal[] animais)
    {
        this.animais = animais;
    }

    Animal[] animais;
}