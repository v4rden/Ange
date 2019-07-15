namespace Ange.Application.User.Commands.CreateUser
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Domain.Entities;
    using Interfaces;
    using MediatR;

    public class CreateUserCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public ICollection<Guid> RecideRooms { get; private set; }
        
        public class Handler : IRequestHandler<CreateUserCommand, Unit>
        {
            private readonly IAngeDbContext _context;
            private readonly IMediator _mediator;

            public Handler(IAngeDbContext context, IMediator mediator)
            {
                _context = context;
                _mediator = mediator;
            }

            public async Task<Unit> Handle(CreateUserCommand request, CancellationToken cancellationToken)
            {
                var entity = new User()
                {
                    Id = request.Id,
                    Name = request.Name,
                    Country = request.Country,
                };

                _context.Users.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);

                await _mediator.Publish(new UserCreated { Id = entity.Id }, cancellationToken);

                return Unit.Value;
            }
        }
    }
}