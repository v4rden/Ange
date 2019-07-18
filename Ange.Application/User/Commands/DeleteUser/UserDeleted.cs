namespace Ange.Application.User.Commands.DeleteUser
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using FluentValidation;
    using Interfaces;
    using MediatR;
    using Notifications;

    public class UserDeleted : INotification
    {
        public Guid Id { get; set; }

        public class UserDeletedHandler : INotificationHandler<UserDeleted>
        {
            private readonly INotificationService _notification;

            public UserDeletedHandler(INotificationService notification)
            {
                _notification = notification;
            }

            public async Task Handle(UserDeleted notification, CancellationToken cancellationToken)
            {
                await _notification.SendAsync(new NotificationMsg());
            }
        }
    }
}