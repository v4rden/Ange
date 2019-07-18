namespace Ange.Application.User.Queries.GetUserList
{
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
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
                Users = await _context.Users
                    .ProjectTo<UserLookupModel>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken)
            };
        }
    }
}