using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dojo
{
    public class Market
    {
        private IList<(int id, Order order)> orders;

        public Market()
        {
            this.orders = new List<(int, Order)>();
        }

        public void AddOrder(Order order)
        {
            this.orders.Add((this.orders.Count, order));
        }

        public int? FindMatch(Order orderToMatch)
        {
            if (orderToMatch == null)
                throw new ArgumentNullException(nameof(orderToMatch));

            var matchedOrder =
            orders
                .Where(order => order.order.FromCurrency == orderToMatch.ToCurrency)
                .Where(order => order.order.ToCurrency == orderToMatch.FromCurrency)
                .Where(order => order.order.ToQuantity >= orderToMatch.FromQuantity)
                //.Where(order => order.order.FromQuantity >= orderToMatch.ToQuantity)
                .OrderBy(order => order.order.ToQuantity)
                .Select(order => (int?)order.id)
                .FirstOrDefault();

            return matchedOrder;
        }

    }


}
