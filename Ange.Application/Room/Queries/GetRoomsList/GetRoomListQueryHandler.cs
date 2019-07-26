namespace Ange.Application.Room.Queries.GetRoomsList
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
    using Remotion.Linq.Clauses;

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
                Rooms = await GetQuery(request)
                    .ProjectTo<RoomLookupModel>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken)
            };
        }

        private IQueryable<Room> GetQuery(GetRoomListQuery request)
        {
            if (request.Title != null)
            {
                return _context.Rooms.Where(r => r.Title.Contains(request.Title));
            }

            if (request.Resident != Guid.Empty)
            {
                return _context.Rooms
                    .SelectMany(room => _context.UserRooms, (room, ur) => new {room, ur})
                    .Where(t => t.ur.RoomId == t.room.Id)
                    .Select(t => t.room);
            }

            return _context.Rooms;
        }
    }
}