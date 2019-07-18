namespace Ange.Application.Room.Queries.GetRoomDetail
{
    using System;
    using MediatR;

    public class GetRoomDetailQuery : IRequest<RoomDetailModel>
    {
        public Guid Id { get; set; }
    }
}