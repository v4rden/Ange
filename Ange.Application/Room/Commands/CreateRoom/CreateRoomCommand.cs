namespace Ange.Application.Room.CreateRoom
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Domain.Entities;
    using Domain.Enumerations;
    using Interfaces;
    using MediatR;
    using User.Commands.CreateUser;

    public class CreateRoomCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public Guid RoomCreator { get; set; }
        public RoomType Type { get; set; }

        public class CreateRoomCommandHandler : IRequestHandler<CreateRoomCommand, Unit>
        {
            private readonly IAngeDbContext _context;
            private readonly IMediator _mediator;

            public CreateRoomCommandHandler(IAngeDbContext context, IMediator mediator)
            {
                _context = context;
                _mediator = mediator;
            }

            public async Task<Unit> Handle(CreateRoomCommand request, CancellationToken cancellationToken)
            {
                var entity = new Room
                {
                    Id = request.Id,
                    Title = request.Title,
                    RoomCreator = request.RoomCreator,
                    Type = request.Type,
                };

                _context.Rooms.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);

                await _mediator.Publish(new RoomCreated {Id = entity.Id}, cancellationToken);

                return Unit.Value;
            }
        }
    }
}