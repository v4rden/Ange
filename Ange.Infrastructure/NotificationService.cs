namespace Ange.Infrastructure
{
    using System.Threading.Tasks;
    using Application.Interfaces;
    using Application.Notifications;

    public class NotificationService : INotificationService
    {
        public Task SendAsync(NotificationMsg message)
        {
            return Task.CompletedTask;
        }
    }
}