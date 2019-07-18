namespace Ange.Application.Room.Queries.GetRoomDetail
{
    using System.Threading;
    using System.Threading.Tasks;
    using Exceptions;
    using Interfaces;
    using MediatR;

    public class GetRoomDetailHandler : IRequestHandler<GetRoomDetailQuery, RoomDetailModel>
    {
        private readonly IAngeDbContext _context;

        public GetRoomDetailHandler(IAngeDbContext context)
        {
            _context = context;
        }

        public async Task<RoomDetailModel> Handle(GetRoomDetailQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Rooms.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Room), request.Id);
            }

            return RoomDetailModel.Create(entity);
        }
    }
}