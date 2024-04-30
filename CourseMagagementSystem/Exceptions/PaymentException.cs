namespace CourseMagagementSystem.Exceptions
{
    public class PaymentException : Exception
    {
        public PaymentException(string message) : base(message) { }
        public PaymentException(string message, Exception ex) : base(message, ex) { }
    }
}
