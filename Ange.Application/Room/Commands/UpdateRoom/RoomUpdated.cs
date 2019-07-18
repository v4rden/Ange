namespace Ange.Application.Room.UpdateRoom
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Interfaces;
    using MediatR;
    using Notifications;

    public class RoomUpdated : INotification
    {
        public Guid Id { get; set; }

        public class RoomUpdatedHandler : INotificationHandler<RoomUpdated>
        {
            private readonly INotificationService _notification;

            public RoomUpdatedHandler(INotificationService notification)
            {
                _notification = notification;
            }

            public async Task Handle(RoomUpdated notification, CancellationToken cancellationToken)
            {
                await _notification.SendAsync(new NotificationMsg());
            }
        }
    }
}