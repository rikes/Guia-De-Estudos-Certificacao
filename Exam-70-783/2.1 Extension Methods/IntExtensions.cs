using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._1_Extension_Methods
{
    // Para extensão do método devemos dizer seu tipo, ser público e estático
    //A diferença para um método estático comum é u uso do this
    public static class IntExtensions 
    {
        public static int Half(this int x)
        {
            return x / 2;
        }

        public static int Add100(this int x)
        {
            return x + 100;
        }
    }
}
