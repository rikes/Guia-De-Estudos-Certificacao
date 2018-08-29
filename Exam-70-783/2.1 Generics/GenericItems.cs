using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._1_Generics
{
    /* Nesta classe Generica, estamos criando um vetor do tipo que foi definido ao Instanciar a classe
     * Além disso, foi aplicado um filtro. Para que somente tipos anuláveis fossem utilizados(struct).
     * Obs.:Tipos de referência como 'string' não estão incluso
     *
     */
    class GenericItems<T> where T : struct 
    {
        private T[] items = new T[50];
        private int numItems = 0;

        public void Add(T item)
        {
            if(numItems + 1 < 50)
            {
                items[numItems] = item;
                numItems++;
            }
        }
        //Ao chamar a instancia da classe passando a posição é retornado o item do vetor correspondente
        //ex: genericItems[1]
        public T this[int index]
        {
            get { return items[index]; }
        }
    }
}
