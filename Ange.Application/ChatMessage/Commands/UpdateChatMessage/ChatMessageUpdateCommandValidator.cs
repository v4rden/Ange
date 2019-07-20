namespace Ange.Application.ChatMessage.Commands.UpdateChatMessage
{
    using FluentValidation;

    public class ChatMessageUpdateCommandValidator : AbstractValidator<ChatMessageUpdateCommand>
    {
        public ChatMessageUpdateCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.RoomId).NotEmpty();
            RuleFor(x => x.AuthorId).NotEmpty();
            RuleFor(x => x.SentTime).NotEmpty();
            RuleFor(x => x.LastModified).GreaterThan(x => x.SentTime).NotEmpty();
            RuleFor(x => x.Type).NotEmpty();
            RuleFor(x => x.MessageText).NotEmpty();
        }
    }
}