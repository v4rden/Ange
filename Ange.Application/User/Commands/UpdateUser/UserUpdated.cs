namespace Ange.Application.User.Commands.UpdateUser
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Interfaces;
    using MediatR;
    using Notifications;

    public class UserUpdated : INotification
    {
        public Guid Id { get; set; }

        public class UserUpdatedHandler : INotificationHandler<UserUpdated>
        {
            private readonly INotificationService _notification;

            public UserUpdatedHandler(INotificationService notification)
            {
                _notification = notification;
            }

            public async Task Handle(UserUpdated notification, CancellationToken cancellationToken)
            {
                await _notification.SendAsync(new NotificationMsg());
            }
        }
    }
}