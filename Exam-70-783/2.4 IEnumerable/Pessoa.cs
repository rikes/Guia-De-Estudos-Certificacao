using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._4_IEnumerable
{
    class Pessoa
    {
        public Pessoa(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public override string ToString()
        {
            return FirstName + " " + LastName;
        }
    }

    class Pessoas : IEnumerable<Pessoa>
    {
        public Pessoas(Pessoa[] Pessoas)
        {
            this.pessoas = Pessoas;
        }

        Pessoa[] pessoas;

        public IEnumerator<Pessoa> GetEnumerator()
        {
            for (int index = 0; index < pessoas.Length; index++)
            {
                // a palavra-chave yield em uma instrução, você indica que o método, o operador ou o acessador get em que ela é exibida é um iterador.
                //Usar yield para definir um iterador elimina a necessidade de uma classe adicional explícita 
                yield return pessoas[index];
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
