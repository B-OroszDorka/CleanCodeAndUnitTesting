public interface IExchangeRateService
{
    double GetExchangeRate(string fromCurrency, string toCurrency);
}
