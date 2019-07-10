using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using WalletKata;

namespace WalletKataTest
{
    [TestClass]
    public class WalletTest
    {
        [TestMethod]
        public void Should_Return_Zero_Amount_When_Wallet_Is_Empty()
        {

            var rateProvider = new Mock<IRateProvider>();

            decimal value = new Wallet(new[] { Stock.Empty() }).Value(Currency.EUR, rateProvider.Object);

            Assert.AreEqual(0, value);
        }

        [TestMethod]
        public void Should_Return_Rate_When_Wallet_Contains_One_Unit_In_One_Stock()
        {
            var rateProvider = new Mock<IRateProvider>();
            rateProvider.Setup(x => x.Rate(StockType.PETROLEUM, Currency.EUR)).Returns(50);

            decimal value = new Wallet(new[] { new Stock(1, StockType.PETROLEUM) }).Value(Currency.EUR, rateProvider.Object);

            Assert.AreEqual(50, value);
        }

        [TestMethod]
        public void Should_Return_The_Stock_Amount_When_Wallet_Contains_Multiple_Units_In_One_Stock()
        {
            var rateProvider = new Mock<IRateProvider>();
            rateProvider.Setup(x => x.Rate(StockType.PETROLEUM, Currency.EUR)).Returns(10);

            decimal value = new Wallet(new[] { new Stock(5, StockType.PETROLEUM) }).Value(Currency.EUR, rateProvider.Object);

            Assert.AreEqual(50, value);
        }

        [TestMethod]
        public void Should_Return_The_Wallet_Amount_When_Wallet_Contains_Multiple_Stocks()
        {
            var rateProvider = new Mock<IRateProvider>();
            rateProvider.Setup(x => x.Rate(StockType.PETROLEUM, Currency.EUR)).Returns(10);
            rateProvider.Setup(x => x.Rate(StockType.BITCOIN, Currency.EUR)).Returns(0.5M);
            rateProvider.Setup(x => x.Rate(StockType.DOLLARS, Currency.EUR)).Returns(0.8M);

            IList<Stock> stockList = new List<Stock>();
            stockList.Add(new Stock(5, StockType.PETROLEUM));
            stockList.Add(new Stock(2, StockType.BITCOIN));
            stockList.Add(new Stock(6, StockType.DOLLARS));

            decimal value = new Wallet(stockList).Value(Currency.EUR, rateProvider.Object);

            Assert.AreEqual(55.8M, value);
        }
    }
}
