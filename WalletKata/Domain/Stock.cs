using System;

namespace WalletKata
{
    public class Stock
    {
        private int _value;
        private StockType? _stockType;

        public int Value { get => _value; set => _value = value; }
        public StockType? StockType { get => _stockType; set => _stockType = value; }

        public Stock(int value, StockType? stockType)
        {
            Value = value;
            _stockType = stockType;
        }

        public static Stock Empty()
        {
            return new Stock(0, null);
        }
    }
}