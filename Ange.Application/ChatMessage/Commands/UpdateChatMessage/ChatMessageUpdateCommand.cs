namespace Ange.Application.ChatMessage.Commands.UpdateChatMessage
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Domain.Enumerations;
    using Exceptions;
    using Interfaces;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public class ChatMessageUpdateCommand : IRequest
    {
        public Guid Id { get; set; }
        public Guid RoomId { get; set; }
        public Guid AuthorId { get; set; }
        public DateTime SentTime { get; set; }
        public DateTime LastModified { get; set; }
        public MessageType Type { get; set; }
        public string MessageText { get; set; }
    }

    public class ChatMessageUpdateCommandHandler : IRequestHandler<ChatMessageUpdateCommand, Unit>
    {
        private readonly IAngeDbContext _context;
        private readonly IMediator _mediator;

        public ChatMessageUpdateCommandHandler(IAngeDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public async Task<Unit> Handle(ChatMessageUpdateCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.ChatMessages
                .SingleOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(User), request.Id);
            }

            entity.RoomId = request.RoomId;
            entity.AuthorId = request.AuthorId;
            entity.SentTime = request.SentTime;
            entity.LastModified = request.LastModified;
            entity.Type = request.Type;
            entity.MessageText = request.MessageText;

            await _context.SaveChangesAsync(cancellationToken);

            await _mediator.Publish(new ChatMessageUpdated {Id = entity.Id}, cancellationToken);

            return Unit.Value;
        }
    }
}