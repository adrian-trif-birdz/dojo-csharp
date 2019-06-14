using NUnit.Framework;

namespace Dojo.Tests
{
    [TestFixture]
    public class DojoTests
    {
        [Test]
        public void Add_ZeroAndZero_ShouldBeZero()
        {
            Assert.AreEqual(0, Dojo.Add(0, 0));
        }

        [Test]
        public void IfMarketEmpty_ShouldBeNull()
        {
            var market = new Market();
            var matchedOrderId = market.FindMatch(new Order(100, Currency.EUR, Currency.USD, 1.2M));
            Assert.AreEqual(matchedOrderId, null);
        }

        [Test]
        public void IfNullOrder_ShouldBeThrowException()
        {
            var market = new Market();
            Assert.Throws<System.ArgumentNullException>(() => market.FindMatch(null));
        }

        [Test]
        public void IfOrderInMarket_ShouldReturnItsID()
        {
            var market = new Market();
            var orderA = new Order(120, Currency.USD, Currency.EUR, 100 / 120);
            var orderB = new Order(100, Currency.EUR, Currency.USD, 120 / 100);
            market.AddOrder(orderA);
            var matchedOrderId = market.FindMatch(orderB);
            Assert.AreEqual(matchedOrderId, 0);
        }
    }
}