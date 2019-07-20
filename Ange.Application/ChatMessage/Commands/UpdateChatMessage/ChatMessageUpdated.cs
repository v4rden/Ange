namespace Ange.Application.ChatMessage.Commands.UpdateChatMessage
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Interfaces;
    using MediatR;
    using Notifications;

    public class ChatMessageUpdated : INotification
    {
        public Guid Id { get; set; }

        public class ChatMessageUpdatedHandler : INotificationHandler<ChatMessageUpdated>
        {
            private readonly INotificationService _notification;

            public ChatMessageUpdatedHandler(INotificationService notification)
            {
                _notification = notification;
            }

            public async Task Handle(ChatMessageUpdated notification, CancellationToken cancellationToken)
            {
                await _notification.SendAsync(new NotificationMsg());
            }
        }
    }
}