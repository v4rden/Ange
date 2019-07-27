namespace Ange.Application.User.Queries.GetUserList
{
    using System;
    using MediatR;

    public class GetUserListQuery : IRequest<UserListViewModel>
    {
        public string Name { get; set; }
        public Guid RoomId { get; set; }
    }
}