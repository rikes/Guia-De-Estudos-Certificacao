using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Definindo uma classe base com repositorio do tipo IEntity
 */
namespace _2._4_Base
{
    /*
     * Propriedades alcancaveis
     */
    interface IEntity
    {
        int Id { get; }

        string descricao { get; set; }
    }

    class Repository<T> where T : IEntity
    {
        protected IEnumerable<T> _elements;

        public Repository(IEnumerable<T> elements)
        {
            _elements = elements;
        }

        public T FindById(int id)
        {
            return _elements.SingleOrDefault(e => e.Id == id);//Id da interface
        }
    }
}
