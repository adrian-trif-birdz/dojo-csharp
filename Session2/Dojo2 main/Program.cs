using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dojo2_main
{
    class Program
    {
        static void Main(string[] args)
        {
        }


    }

    public class Lib
    {
        public bool AMethod()
        {
            return true;
        }
    }

    public class Market
    {
        private readonly IList<Offer> offers;

        public Market()
        {
            this.offers = new List<Offer>();
        }

        public ICollection<string> FindSolution()
        {
            return this.FindSolutionCore(this.offers).ToArray();
        }

        private IEnumerable<string> FindSolutionCore(IEnumerable<Offer> offers)
        {
            if (!offers.Any())
            {
                return Enumerable.Empty<string>();
            }

            var firstOffer = offers.First();
            var nextOffers = offers.Except(new[] { firstOffer });
            return this.FindSolutionCore(nextOffers);
        }

        public void AddOffer(Offer offer)
        {
            this.offers.Add(offer);
        }
    }

    public class Offer
    {
        public string Id { get; }
        public Amount FromAmount { get; }
        public Amount ToAmount { get; }

        public Offer(string id, Amount fromAmount, Amount toAmount)
        {
            this.Id = id;
            this.FromAmount = fromAmount;
            this.ToAmount = toAmount;
        }
    }

    public enum Currency
    {
        Eur,
        Usd,
        Gbp
    }


    public class Amount
    {
        public decimal Value { get; }
        public Currency Currency { get; }

        public Amount(decimal value, Currency currency)
        {
            this.Value = value;
            this.Currency = currency;
        }
    }
}