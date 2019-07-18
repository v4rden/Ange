namespace Ange.Application.User.Queries.GetUserDetail
{
    using System.Threading;
    using System.Threading.Tasks;
    using Exceptions;
    using Interfaces;
    using MediatR;

    public class GetUserDetailHandler : IRequestHandler<GetUserDetailQuery, UserDetailModel>
    {
        private readonly IAngeDbContext _context;

        public GetUserDetailHandler(IAngeDbContext context)
        {
            _context = context;
        }

        public async Task<UserDetailModel> Handle(GetUserDetailQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Users.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(User), request.Id);
            }

            return UserDetailModel.Create(entity);
        }
    }
}