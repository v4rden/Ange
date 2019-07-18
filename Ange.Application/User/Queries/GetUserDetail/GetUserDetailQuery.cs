namespace Ange.Application.User.Queries.GetUserDetail
{
    using MediatR;

    public class GetUserDetailQuery : IRequest<UserDetailModel>
    {
        public string Id { get; set; }
    }
}