namespace Ange.Application.ChatMessage.Queries.GetChatMessageDetail
{
    using System.Threading;
    using System.Threading.Tasks;
    using Exceptions;
    using Interfaces;
    using MediatR;

    public class GetChatMessageDetailHandler : IRequestHandler<GetChatMessageDetailQuery, ChatMessageDetailModel>
    {
        private readonly IAngeDbContext _context;

        public GetChatMessageDetailHandler(IAngeDbContext context)
        {
            _context = context;
        }

        public async Task<ChatMessageDetailModel> Handle(GetChatMessageDetailQuery request,
            CancellationToken cancellationToken)
        {
            var entity = await _context.ChatMessages.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(ChatMessage), request.Id);
            }

            return ChatMessageDetailModel.Create(entity);
        }
    }
}