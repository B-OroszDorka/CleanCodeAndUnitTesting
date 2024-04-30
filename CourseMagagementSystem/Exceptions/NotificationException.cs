namespace CourseMagagementSystem.Exceptions
{
    public class NotificationException : Exception
    {
        public NotificationException(string message) : base(message) { }
        public NotificationException(string message, Exception ex) : base(message, ex) { }
    }

    public class EmailException : NotificationException
    {
        public EmailException(string message) : base(message) { }
        public EmailException(string message, Exception ex) : base(message, ex) { }
    }

    public class PushNotificationException : NotificationException
    {
        public PushNotificationException(string message) : base(message) { }
        public PushNotificationException(string message, Exception ex) : base(message, ex) { }
    }
}
