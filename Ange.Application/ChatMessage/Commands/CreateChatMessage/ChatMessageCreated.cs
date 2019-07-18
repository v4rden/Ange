namespace Ange.Application.ChatMessage.Commands.CreateChatMessage
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Interfaces;
    using MediatR;
    using Notifications;

    public class ChatMessageCreated : INotification
    {
        public Guid Id { get; set; }

        public class ChatMessageCreatedHandler : INotificationHandler<ChatMessageCreated>
        {
            private readonly INotificationService _notification;

            public ChatMessageCreatedHandler(INotificationService notification)
            {
                _notification = notification;
            }

            public async Task Handle(ChatMessageCreated notification, CancellationToken cancellationToken)
            {
                await _notification.SendAsync(new NotificationMsg());
            }
        }
    }
}