namespace Ange.Application.ChatMessage.Commands.UpdateChatMessage
{
    using System.Threading;
    using System.Threading.Tasks;
    using Interfaces;
    using MediatR;
    using Notifications;

    public class ChatMessageUpdated : INotification
    {
        private readonly INotificationService _notification;

        public ChatMessageUpdated(INotificationService notification)
        {
            _notification = notification;
        }

        public async Task Handle(ChatMessageUpdated notification, CancellationToken cancellationToken)
        {
            await _notification.SendAsync(new NotificationMsg());
        }
    }
}