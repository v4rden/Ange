namespace Ange.Application.Room.Queries.GetRoomsList
{
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Interfaces;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public class GetRoomListQueryHandler : IRequestHandler<GetRoomListQuery, RoomListViewModel>
    {
        private readonly IAngeDbContext _context;
        private readonly IMapper _mapper;

        public GetRoomListQueryHandler(IAngeDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<RoomListViewModel> Handle(GetRoomListQuery request, CancellationToken cancellationToken)
        {
            return new RoomListViewModel
            {
                Rooms = await _context.Rooms
                    .ProjectTo<RoomLookupModel>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken)
            };
        }
    }
}