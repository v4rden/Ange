namespace Ange.Application.User.Queries.GetUserList
{
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Domain.Entities;
    using Interfaces;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public class GetUserListQueryHandler : IRequestHandler<GetUserListQuery, UserListViewModel>
    {
        private readonly IAngeDbContext _context;
        private readonly IMapper _mapper;

        public GetUserListQueryHandler(IAngeDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<UserListViewModel> Handle(GetUserListQuery request, CancellationToken cancellationToken)
        {
            return new UserListViewModel
            {
                Users = await GetQuery(request)
                    .ProjectTo<UserLookupModel>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken)
            };
        }

        private IQueryable<User> GetQuery(GetUserListQuery request)
        {
            if (string.IsNullOrEmpty(request.Name))
            {
                return _context.Users.Where(u => u.Name.Contains(request.Name));
            }

            if (request.RoomId != Guid.Empty)
            {
                return _context.Users
                    .SelectMany(user => _context.UserRooms,
                        (user, userRoom) => new {user, userRoom})
                    .Where(t => t.userRoom.RoomId == request.RoomId
                                && t.userRoom.UserId == t.user.Id)
                    .Select(t => t.user);
            }

            return _context.Users;
        }
    }
}