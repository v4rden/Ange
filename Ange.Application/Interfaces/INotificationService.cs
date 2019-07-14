namespace Ange.Application.Interfaces
{
    using System.Threading.Tasks;
    using Notifications;

    public interface INotificationService
    {
        Task SendAsync(NotificationMsg message);
    }
}