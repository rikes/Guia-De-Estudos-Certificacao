using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._4_Base
{
    class Program
    {
        static void Main(string[] args)
        {
            Order ordem = new Order();
            ordem.Id = 33;
            IEnumerable<Order> ie = new List<Order>() {ordem};

            OrderRepository repository = new OrderRepository(ie);

            var result = repository.FindById(33);
            repository.FilterOrdersOnAmount(33m);
            

        }
    }
}
