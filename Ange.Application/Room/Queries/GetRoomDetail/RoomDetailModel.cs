namespace Ange.Application.Room.Queries.GetRoomDetail
{
    using System;
    using System.Linq.Expressions;
    using Domain.Entities;
    using Domain.Enumerations;

    public class RoomDetailModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public Guid RoomCreator { get; set; }
        public RoomType Type { get; set; }

        public static Expression<Func<Room, RoomDetailModel>> Projection
        {
            get
            {
                return room => new RoomDetailModel
                {
                    Id = room.Id,
                    Title = room.Title,
                    RoomCreator = room.RoomCreator,
                    Type = room.Type
                };
            }
        }

        public static RoomDetailModel Create(Room room)
        {
            return Projection.Compile().Invoke(room);
        }
    }
}