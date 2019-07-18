namespace Ange.Application.User.Commands.UpdateUser
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Exceptions;
    using Interfaces;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public class UpdateUserCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
    }

    public class Handler : IRequestHandler<UpdateUserCommand, Unit>
    {
        private readonly IAngeDbContext _context;
        private readonly IMediator _mediator;

        public Handler(IAngeDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Users
                .SingleOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(User), request.Id);
            }

            entity.Name = request.Name;
            entity.Country = request.Country;

            await _context.SaveChangesAsync(cancellationToken);

            await _mediator.Publish(new UserUpdated {Id = entity.Id}, cancellationToken);

            return Unit.Value;
        }
    }
}