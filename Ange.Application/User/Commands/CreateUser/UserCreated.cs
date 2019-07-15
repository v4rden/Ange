namespace Ange.Application.User.Commands.CreateUser
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Interfaces;
    using MediatR;
    using Notifications;

    public class UserCreated : INotification
    {
        public Guid Id { get; set; }
        
        public class UserCreatedHandler : INotificationHandler<UserCreated>
        {
            private readonly INotificationService _notification;

            public UserCreatedHandler(INotificationService notification)
            {
                _notification = notification;
            }

            public async Task Handle(UserCreated notification, CancellationToken cancellationToken)
            {
                await _notification.SendAsync(new NotificationMsg());
            }
        }
    }
}