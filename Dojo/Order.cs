using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dojo
{
    public class Order
    {

        public decimal FromQuantity { get; }

        public Currency FromCurrency { get; }

        public decimal ToQuantity { get; }

        public Currency ToCurrency { get; }

        public Order(decimal quantity, Currency from, Currency to, decimal ratio)
        {
            this.FromQuantity = quantity;
            this.FromCurrency = from;
            this.ToCurrency = to;
            this.ToQuantity = quantity * ratio;
        }
    }
}
