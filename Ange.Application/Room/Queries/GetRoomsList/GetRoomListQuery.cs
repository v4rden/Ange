namespace Ange.Application.Room.Queries.GetRoomsList
{
    using System;
    using MediatR;

    public class GetRoomListQuery : IRequest<RoomListViewModel>
    {
        public string Title { get; set; }
        public Guid Resident { get; set; }
    }
}