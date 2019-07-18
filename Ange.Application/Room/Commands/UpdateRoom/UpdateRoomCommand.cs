namespace Ange.Application.Room.UpdateRoom
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Exceptions;
    using Interfaces;
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using User.Commands.UpdateUser;

    public class UpdateRoomCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Title { get; set; }

        public class UpdateRoomCommandHandler : IRequestHandler<UpdateRoomCommand, Unit>
        {
            private readonly IAngeDbContext _context;
            private readonly IMediator _mediator;

            public UpdateRoomCommandHandler(IAngeDbContext context, IMediator mediator)
            {
                _context = context;
                _mediator = mediator;
            }

            public async Task<Unit> Handle(UpdateRoomCommand request, CancellationToken cancellationToken)
            {
                var entity = await _context.Rooms
                    .SingleOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(Room), request.Id);
                }

                entity.Title = request.Title;

                await _context.SaveChangesAsync(cancellationToken);

                await _mediator.Publish(new RoomUpdated {Id = entity.Id}, cancellationToken);

                return Unit.Value;
            }
        }
    }
}