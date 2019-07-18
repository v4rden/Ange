namespace Ange.Application.ChatMessage.Commands.CreateChatMessage
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Domain.Entities;
    using Domain.Enumerations;
    using Interfaces;
    using MediatR;

    public class CreateChatMessageCommand : IRequest
    {
        public Guid Id { get; set; }
        public Guid Room { get; set; }
        public Guid Author { get; set; }
        public DateTime SentTime { get; set; }
        public DateTime LastModified { get; set; }
        public MessageType Type { get; set; }
        public string MessageText { get; set; }

        public class CreateChatMessageCommandHandler : IRequestHandler<CreateChatMessageCommand, Unit>
        {
            private readonly IAngeDbContext _context;
            private readonly IMediator _mediator;

            public CreateChatMessageCommandHandler(IAngeDbContext context, IMediator mediator)
            {
                _context = context;
                _mediator = mediator;
            }

            public async Task<Unit> Handle(CreateChatMessageCommand request, CancellationToken cancellationToken)
            {
                var entity = new ChatMessage
                {
                    Id = request.Id,
                    Room = request.Room,
                    Author = request.Author,
                    SentTime = request.SentTime,
                    LastModified = request.LastModified,
                    Type = request.Type,
                    MessageText = request.MessageText,
                };

                _context.ChatMessages.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);

                await _mediator.Publish(new ChatMessageCreated {Id = entity.Id}, cancellationToken);

                return Unit.Value;
            }
        }
    }
}