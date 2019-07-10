using System;
using System.Collections.Generic;

namespace WalletKata
{
    public class Wallet
    {
        private IList<Stock> _stockList;

        public Wallet(IList<Stock> stockList)
        {
            this._stockList = stockList;
        }

        public decimal Value(Currency currency, IRateProvider rateProvider)
        {
            decimal amount = 0;
            foreach (var stock in _stockList)
            {
                var rate = rateProvider.Rate(stock.StockType, currency);
                amount += rate * stock.Value;
            }

            return amount;
        }
    }
}