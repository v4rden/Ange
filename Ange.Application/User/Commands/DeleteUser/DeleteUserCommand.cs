namespace Ange.Application.User.Commands.DeleteUser
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Exceptions;
    using Interfaces;
    using MediatR;

    public class DeleteUserCommand : IRequest
    {
        public Guid Id { get; set; }

        public class DeleteCustomerCommandHandler : IRequestHandler<DeleteUserCommand, Unit>
        {
            private readonly IAngeDbContext _context;
            private readonly IMediator _mediator;

            public DeleteCustomerCommandHandler(IAngeDbContext context, IMediator mediator)
            {
                _context = context;
                _mediator = mediator;
            }

            public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
            {
                var entity = await _context.Users
                    .FindAsync(request.Id);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(User), request.Id);
                }

                _context.Users.Remove(entity);

                await _context.SaveChangesAsync(cancellationToken);

                await _mediator.Publish(new UserDeleted {Id = request.Id}, cancellationToken);

                return Unit.Value;
            }
        }
    }
}