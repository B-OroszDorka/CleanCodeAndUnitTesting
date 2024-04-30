namespace CourseMagagementSystem.Exceptions
{
    public class DbClientException : Exception
    {
        public DbClientException(string message) : base(message) { }
        public DbClientException(string message, Exception ex) : base(message, ex) { }
    }

    public class AddingToDbException : DbClientException 
    {
        public AddingToDbException(string message) : base(message) { }
        public AddingToDbException(string message, Exception ex) : base(message, ex) { }
    }

    public class GettingFromDbException : DbClientException
    {
        public GettingFromDbException(string message) : base(message) { }
        public GettingFromDbException(string message, Exception ex) : base(message, ex) { }
    }
}
