using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._2_Operrator_Explicit_Implicit
{
    class Money
    {
        public Money(decimal amount)
        {
            Amount = amount;
        }

        public Money(int amount)
        {
            Amount = amount;
        }

        public decimal Amount { get; set; }


        public static implicit operator decimal(Money money)
        {
            return money.Amount;
        }

        public static implicit operator int(Money money)
        {
            return (int)money.Amount;
        }

        public static implicit operator string(Money money)
        {
            return money.Amount.ToString();
        }

        //Pode lancar uma excpetion
        public static explicit operator Money(string money)
        {
            return new Money(Convert.ToDecimal(money));
        }


        //public static explicit operator int(Money money)
        //{
        //    return (int)money.Amount;
        //}
    }
}
