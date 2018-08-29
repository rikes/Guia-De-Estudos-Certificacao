using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._1_Extension_Methods
{
    //Extensao de métodos do tipo Date
    //A diferença para um método estático comum é o uso do this
    public static class DateExtensions
    {
        //Retornar uma String com mes ano de uma data especifica;
        public static string MesAno(this DateTime date)
        {
            return string.Format("{0}/{1}", date.Month, date.Year);
        }
        



    }
}
