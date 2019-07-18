namespace Ange.Application.Room.CreateRoom
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Interfaces;
    using MediatR;
    using Notifications;

    public class RoomCreated : INotification
    {
        public Guid Id { get; set; }

        public class RoomCreatedHandler : INotificationHandler<RoomCreated>
        {
            private readonly INotificationService _notification;

            public RoomCreatedHandler(INotificationService notification)
            {
                _notification = notification;
            }

            public async Task Handle(RoomCreated notification, CancellationToken cancellationToken)
            {
                await _notification.SendAsync(new NotificationMsg());
            }
        }
    }
}