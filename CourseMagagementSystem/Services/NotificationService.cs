using CourseMagagementSystem.Abstractions.Clients;
using CourseMagagementSystem.Abstractions.Services;
using CourseMagagementSystem.Exceptions;
using Microsoft.Extensions.Logging;

namespace CourseMagagementSystem.Services
{
    public class NotificationService : INotificationService
    {
        private readonly List<INotificationClient> _notificationClients = new();
        private readonly ILogger<NotificationService> _logger;

        public NotificationService(INotificationClient emailClient, INotificationClient pushNotificationClient, ILogger<NotificationService> logger)
        {
            _notificationClients.Add(emailClient);
            _notificationClients.Add(pushNotificationClient);
            _logger = logger;
        }

        public async Task SendNotification(string message)
        {
            foreach (var client in _notificationClients)
            {
                try
                {
                    await client.SendNotification(message);
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Couldn't send notification with the following message: {message}");
                    throw new NotificationException($"Couldn't send notification with the following message: {message}", ex);
                }
            }
        }
    }
}
