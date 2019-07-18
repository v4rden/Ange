namespace Ange.Application.User.Queries.GetUserDetail
{
    using System;
    using MediatR;

    public class GetUserDetailQuery : IRequest<UserDetailModel>
    {
        public Guid Id { get; set; }
    }
}