namespace Ange.Application.ChatMessage.Commands.CreateChatMessage
{
    using FluentValidation;

    public class CreateChatMessageCommandValidator : AbstractValidator<CreateChatMessageCommand>
    {
        public CreateChatMessageCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Room).NotEmpty();
            RuleFor(x => x.Author).NotEmpty();
            RuleFor(x => x.SentTime).NotEmpty();
            RuleFor(x => x.LastModified).NotEmpty();
            RuleFor(x => x.Type).NotEmpty();
            RuleFor(x => x.MessageText).NotEmpty();
        }
    }
}