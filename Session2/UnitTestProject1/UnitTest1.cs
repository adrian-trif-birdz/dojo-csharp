using System;
using System.Collections;
using Dojo2_main;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void NoSolutionOnEmptyMarket()
        {
            var market = new Market();
            var solution = market.FindSolution();
            CollectionAssert.AreEqual((ICollection)solution, null);
        }

        [TestMethod]
        public void NoSolutionOnSingleOfferMarket()
        {
            var market = new Market();
            market.AddOffer(new Offer(Guid.NewGuid().ToString("N"), new Amount(80.0M, Currency.Eur), new Amount(100.0M, Currency.Usd)));
            var solution = market.FindSolution();
            CollectionAssert.AreEqual((ICollection)solution, null);
        }

        [TestMethod]
        public void ASingleResult()
        {
            var market = new Market();
            market.AddOffer(new Offer("1", new Amount( 80.0M, Currency.Eur), new Amount(100.0M, Currency.Usd)));
            market.AddOffer(new Offer("2", new Amount(105.0M, Currency.Usd), new Amount( 90.0M, Currency.Gbp)));
            market.AddOffer(new Offer("3", new Amount( 90.0M, Currency.Gbp), new Amount( 80.0M, Currency.Eur)));
            var solution = market.FindSolution();
            CollectionAssert.AreEqual((ICollection)solution, new[] { "1", "3", "2" });
        }
    }
}
