namespace WalletKata
{
    public interface IRateProvider
    {
        decimal Rate(StockType? stockType, Currency currency);
    }
}