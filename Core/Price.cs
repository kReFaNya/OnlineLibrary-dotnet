using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public struct Price
    {
        public double Amount;
        public string Currency;

        public Price(double amount, string currency)
        {
            Amount = amount;
            Currency = currency;
        }
    }
}
