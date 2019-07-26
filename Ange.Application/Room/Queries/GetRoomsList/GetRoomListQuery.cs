namespace Ange.Application.Room.Queries.GetRoomsList
{
    using MediatR;

    public class GetRoomListQuery : IRequest<RoomListViewModel>
    {
        public string Title { get; set; }
    }
}