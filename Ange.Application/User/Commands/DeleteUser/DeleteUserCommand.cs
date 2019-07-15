namespace Ange.Application.User.Commands.DeleteUser
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Exceptions;
    using Interfaces;
    using MediatR;

    public class DeleteUserCommand : IRequest
    {
        public string Id { get; set; }

        public class DeleteCustomerCommandHandler : IRequestHandler<DeleteUserCommand>
        {
            private readonly IAngeDbContext _context;

            public DeleteCustomerCommandHandler(IAngeDbContext context)
            {
                _context = context;
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

                return Unit.Value;
            }
        }
    }
}