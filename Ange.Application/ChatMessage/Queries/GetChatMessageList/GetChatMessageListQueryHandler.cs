namespace Ange.Application.ChatMessage.Queries.GetChatMessageList
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Domain.Entities;
    using Interfaces;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public class GetChatMessageListQueryHandler : IRequestHandler<GetChatMessageListQuery, ChatMessageListViewModel>
    {
        private readonly IAngeDbContext _context;
        private readonly IMapper _mapper;

        public GetChatMessageListQueryHandler(IAngeDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ChatMessageListViewModel> Handle(GetChatMessageListQuery request,
            CancellationToken cancellationToken)
        {
            return new ChatMessageListViewModel
            {
                ChatMessages = await _context.ChatMessages
                    .ProjectTo<ChatMessageLookupModel>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken)
            };
        }

        private IQueryable<ChatMessage> GetQuery(GetChatMessageListQuery request)
        {
            if (!string.IsNullOrEmpty(request.SubString))
            {
                return _context.ChatMessages.Where(m => m.MessageText.Contains(request.SubString));
            }

            return _context.ChatMessages;
        }
    }
}