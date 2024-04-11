namespace ComplexUnitTestingHomeworkWeek2
{
    public class CustomCurrencyException : Exception
    {
        public CustomCurrencyException(string message) : base(message)
        {
        }
        public CustomCurrencyException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public class CustomCurrencyConverterException : CustomCurrencyException
        {
            public CustomCurrencyConverterException(string message) : base(message)
            {
            }

            public CustomCurrencyConverterException(string message, Exception innerException) : base(message, innerException)
            {
            }
        }
        public class ExchangeRateNotFoundException : CustomCurrencyException
        {
            public ExchangeRateNotFoundException(string message) : base(message)
            {
            }
            public ExchangeRateNotFoundException(string message, Exception innerException) : base(message, innerException)
            {
            }

        }
    }
}
