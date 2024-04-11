using static ComplexUnitTestingHomeworkWeek2.CustomCurrencyException;

namespace ComplexUnitTestingHomeworkWeek2
{
    internal class Currency
    {
        private int _fixedAmount;
        IExchangeRateService _exchangeRateService;
        public Currency(int fixedAmount, IExchangeRateService exchangeRateService) 
        { 
            _fixedAmount = fixedAmount;
            _exchangeRateService = exchangeRateService;
        }

        /// <summary>
        /// Converts the given amount from one currency to another
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="fromCurrency"></param>
        /// <param name="toCurrency"></param>
        /// <returns></returns>
        public double Convert(double amount, string fromCurrency, string toCurrency)
        {
            double exchangeRate;
            try
            {
                exchangeRate = GetExchangeRate(fromCurrency, toCurrency);
                ValidateExchangeRate(exchangeRate);
                return amount * exchangeRate;
            }
            catch (Exception ex)
            {
                throw new CustomCurrencyConverterException($"Error retrieving exchange rate: {ex.Message}", ex);
            }            
        }

        /// <summary>
        /// Generates a conversion report for a given period
        /// </summary>
        /// <param name="fromCurrency"></param>
        /// <param name="toCurrency"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public string GenerateConversionReport(string fromCurrency, string toCurrency, DateTime startDate, DateTime endDate)
        {
            var conversions = new List<double>();
            var currentDate = startDate;

            while (currentDate <= endDate)
            {
                double exchangeRate;
                try
                {
                    exchangeRate = GetExchangeRate(fromCurrency, toCurrency);
                }
                catch (Exception ex)
                {
                    throw new CustomCurrencyConverterException("Error retrieving exchange rate", ex);
                }

                ValidateExchangeRate(exchangeRate);
                CalculateConversion(exchangeRate, conversions);
                currentDate = currentDate.AddDays(1);
            }

            return "Conversion Report:\n" + string.Join("\n", conversions);
        }

        /// <summary>
        /// Calculates the conversion amount and adds it to the list
        /// </summary>
        /// <param name="exchangeRate"></param>
        /// <param name="conversions"></param>
        private void CalculateConversion(double exchangeRate, List<double> conversions)
        {
            var convertedAmount = _fixedAmount * exchangeRate; // Assume a fixed amount for simplicity
            conversions.Add(convertedAmount);
        }

        /// <summary>
        /// Retrieves the exchange rate for the specified currencies
        /// </summary>
        /// <param name="fromCurrency"></param>
        /// <param name="toCurrency"></param>
        /// <returns></returns>
        public double GetExchangeRate(string fromCurrency, string toCurrency)
        {
            try
            {
                // For demonstration purposes, let's assume a fixed exchange rate of 1.2 for USD to EUR
                if (fromCurrency == "USD" && toCurrency == "EUR")
                {
                    return 1.2;
                }
                else
                {
                    // If exchange rate is not available for the given currencies, throw an exception
                    throw new ExchangeRateNotFoundException($"Exchange rate not found for {fromCurrency} to {toCurrency}");
                }
            }
            catch (ExchangeRateNotFoundException ex)
            {
                throw new ExchangeRateNotFoundException($"The exchange has failed from {fromCurrency} to {toCurrency}: {ex.Message}");
            }           
        }


        /// <summary>
        /// Validates the exchange rate
        /// </summary>
        /// <param name="exchangeRate"></param>
        /// <exception cref="CustomCurrencyConverterException"></exception>
        public static void ValidateExchangeRate(double exchangeRate)
        {
            if (exchangeRate == 0 || double.IsNaN(exchangeRate))
            {
                throw new CustomCurrencyConverterException("Invalid exchange rate");
            }
        }

        /// <summary>
        /// Validates the input amount
        /// </summary>
        /// <param name="amount"></param>
        /// <exception cref="CustomCurrencyConverterException"></exception>
        public double ValidateAmount(double amount)
        {
            if (double.IsNaN(amount))
            {
                throw new CustomCurrencyConverterException("Invalid amount input");
            }
            return amount;
        }
    }
}
