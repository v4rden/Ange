namespace Ange.Application.User.Queries.GetUserList
{
    using MediatR;

    public class GetUserListQuery : IRequest<UserListViewModel>
    {
        public string Name { get; set; }
    }
}