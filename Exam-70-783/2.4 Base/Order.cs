using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._4_Base
{
    class Order : IEntity
    {
        public string descricao { get; set; }

        public int Id { get; set; }
        // Other implementation details omitted
    }

    class OrderRepository : Repository<Order>
    {
        //Armazeno 'orders' passado por parametro na classe base(pai). Em '_elements'
        public OrderRepository(IEnumerable<Order> orders) : base(orders) { }

        public IEnumerable<Order> FilterOrdersOnAmount(decimal amount)
        {
            List<Order> result = null;
            // Some filtering code
            return result;
        }
    }
}
