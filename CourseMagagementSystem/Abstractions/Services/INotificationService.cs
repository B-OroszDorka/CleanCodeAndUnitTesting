namespace CourseMagagementSystem.Abstractions.Services
{
    public interface INotificationService
    {
        public Task SendNotification(string message);
    }
}
