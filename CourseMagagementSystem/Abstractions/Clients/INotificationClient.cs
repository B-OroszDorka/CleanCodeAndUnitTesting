namespace CourseMagagementSystem.Abstractions.Clients
{
    public interface INotificationClient
    {
        public Task SendNotification(string message);
    }
}
